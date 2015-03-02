using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Cerebro
{
    internal class Vision
    {
        internal int personas_detectadas = 0;
        internal List<string> personas_reconocidas;
        internal List<Rectangle> last_positions;
        internal List<Image<Gray, byte>> caras_detectadas;
        internal List<bool> reconocido;

        Vision_Full_Form form = null;
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels;
        string name, names = null;

        int desconocidos = 0;

        //Eigen face recognizer
        EigenObjectRecognizer recognizer;
        MCvTermCriteria termCrit;

        internal Vision()
        {
            personas_reconocidas = new List<string>();
            caras_detectadas = new List<Image<Gray, byte>>();
            last_positions = new List<Rectangle>();
            reconocido = new List<bool>();

            //TermCriteria for face recognition with numbers of trained images like maxIteration
            termCrit = new MCvTermCriteria(ContTrain, 0.001);

             
        }


        internal void Iniciar()
        {
            
            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);

            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
                Train();

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Cerebro.consola.println("Vision activada.");
        }

        void FrameGrabber(object sender, EventArgs e)
        {

            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(640, 480, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));
            if (personas_detectadas != facesDetected[0].Length)
            {
                personas_detectadas = facesDetected[0].Length;
                if (personas_detectadas != 0)
                {
                    Cerebro.consola.println(personas_detectadas + " personas detectadas");
                }
            }
            //Action for each element detected
            
            foreach (MCvAvgComp f in facesDetected[0])
            {

                Recognize(f);
            }

            for (int i = 0; i < last_positions.Count; i++ )
            {
                if(reconocido[i]==false)
                {
                    Track(last_positions[i],i);
                }
            }

                if (form != null)
                {
                    form.Set_Current_Frame(currentFrame);
                    form.Set_Faces(caras_detectadas);
                }
            
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();
            caras_detectadas.Clear();
            for (int i = 0; i < reconocido.Count; i++)
                reconocido[i] = false;
        }

        void Recognize(MCvAvgComp f)
        {
            result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //draw the face detected in the 0th (gray) channel with blue color
            currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


            if (trainingImages.ToArray().Length != 0)
            {


                float[] distances = recognizer.GetEigenDistances(result);
                name = recognizer.Recognize(result);
                if (name == null || name == "")
                {
                    name = "desconocido_" + desconocidos;
                    desconocidos++;
                }
                if (!personas_reconocidas.Exists(n => n == name))
                {
                    personas_reconocidas.Add(name);
                    last_positions.Add(f.rect);
                    reconocido.Add(true);
                    Cerebro.consola.println("Reconocí a " + name);
                }
                else
                {
                    int index = personas_reconocidas.IndexOf(name);
                    last_positions[index] = f.rect;
                    reconocido[index] = true;
                }
                caras_detectadas.Add(result);
                //Draw the label for each face detected and recognized
                currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));



                if (distances.Length > 0)
                {
                    //Cerebro.consola.println(distances[0].ToString());
                    float min_distance = 9999999.0f;
                    foreach (float distance in distances)
                    {
                        if (distance < min_distance)
                            min_distance = distance;
                    }
                    if (min_distance > 1600)
                    {
                        trainingImages.Add(result);
                        labels.Add(name);
                        //Write the number of triained faces in a file text for further load
                        File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                        //Write the labels of triained faces in a file text for further load
                        for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                        {
                            trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                            File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                        }
                        Train();
                    }
                }


            }
            if (desconocidos > 0)
            {
                Cerebro.consola.println(" Desconocidos detectados");
            }
        }

        void Track(Rectangle rect, int index)
        {
            int pixels_move = 5;
            Rectangle tmp = rect;
            tmp.X += pixels_move;
            Image<Gray, byte> pos_1 = currentFrame.Copy(tmp).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            tmp = rect;
            tmp.X -= pixels_move;
            Image<Gray, byte> pos_2 = currentFrame.Copy(tmp).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            tmp = rect;
            tmp.Y += pixels_move;
            Image<Gray, byte> pos_3 = currentFrame.Copy(tmp).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            tmp = rect;
            tmp.Y -= pixels_move;
            Image<Gray, byte> pos_4 = currentFrame.Copy(tmp).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);


            


            if (trainingImages.ToArray().Length != 0)
            {
                name = personas_reconocidas[index];

                float min_distance = 9999999.0f;
                float[] distances = recognizer.GetEigenDistances(pos_1);
                int closest_position = 1;
                if (distances.Length > 0)
                {
                    foreach (float distance in distances)
                    {
                        if (distance < min_distance)
                            min_distance = distance;
                    }
                }

                distances = recognizer.GetEigenDistances(pos_2);
                
                if (distances.Length > 0)
                {
                    foreach (float distance in distances)
                    {
                        if (distance < min_distance)
                        {
                            min_distance = distance;
                            closest_position = 2;
                        }
                    }
                }

                distances = recognizer.GetEigenDistances(pos_3);
                
                if (distances.Length > 0)
                {
                    foreach (float distance in distances)
                    {
                        if (distance < min_distance)
                        {
                            closest_position = 3;
                            min_distance = distance;
                        }
                    }
                }

                distances = recognizer.GetEigenDistances(pos_4);
                
                if (distances.Length > 0)
                {
                    foreach (float distance in distances)
                    {
                        if (distance < min_distance)
                        {
                            min_distance = distance;
                            closest_position = 4;
                        }
                    }
                }

                if (min_distance < 1400)
                {
                    
                    switch (closest_position)
                    {
                        case 1:
                            rect.X += pixels_move;
                            break;
                        case 2:
                            rect.X -= pixels_move;
                            break;
                        case 3:
                            rect.Y += pixels_move;
                            break;
                        case 4:
                            rect.Y -= pixels_move;
                            break;
                    }
                    currentFrame.Draw(name, ref font, new Point(rect.X - 2, rect.Y - 2), new Bgr(Color.LightGreen));
                    currentFrame.Draw(rect, new Bgr(Color.Yellow), 2);
                    last_positions[index] = rect;

                    if (min_distance > 1700)
                    {
                        trainingImages.Add(result);
                        labels.Add(name);
                        //Write the number of triained faces in a file text for further load
                        File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                        //Write the labels of triained faces in a file text for further load
                        for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                        {
                            trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                            File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                        }
                        Train();
                    }
                }


            }
            if (desconocidos > 0)
            {
                Cerebro.consola.println(" Desconocidos detectados");
            }
        }

        void Train()
        {
            recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3500,
                       ref termCrit);
        }

        internal void Show_Vision(bool show)
        {
            if (show == true)
            {
                form = new Vision_Full_Form();
                form.Show();
            }
            else
            {
                form.Close();
                form.Dispose();
                form = null;
            }
        }
    }
}
    
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
using Anndrea_Interfaces;

namespace Vision
{
    internal class Vision
    {
        
        internal int detected_people = 0;
        internal List<string> recognized_people;
        internal List<Image<Gray, byte>> recognized_faces;
        internal List<Rectangle> last_positions;
        internal List<DateTime> last_detection_time;
        internal List<Image<Gray, byte>> detected_faces;
        internal List<bool> recognized_flags;

        Vision_Full_Form form_vision = null;
        Image<Bgr, Byte> current_frame;
        Capture grabber = null;
        HaarCascade frontal_face_pattern;

        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> training_images = new List<Image<Gray, byte>>();
        List<string> face_labels = new List<string>();

        int ContTrain, NumLabels;
        string name;

        int unknown_people = 0;

        //Eigen face recognizer
        EigenObjectRecognizer recognizer;
        MCvTermCriteria termCrit;

        EventHandler m_Idle_Handler;

        ITerminal m_Terminal;

        internal Vision(ITerminal terminal)
        {
            recognized_people = new List<string>();
            recognized_faces = new List<Image<Gray, byte>>();
            detected_faces = new List<Image<Gray, byte>>();
            last_positions = new List<Rectangle>();
            recognized_flags = new List<bool>();
            last_detection_time = new List<DateTime>();

            //TermCriteria for face recognition with numbers of trained images like maxIteration
            termCrit = new MCvTermCriteria(ContTrain, 0.001);

            m_Terminal = terminal;
        }

        internal void Stop()
        {
            if (grabber != null)
            {
                Application.Idle -= m_Idle_Handler;
                grabber.Dispose();
                grabber = null;
            }
        }

        internal void Start()
        {

            //Initialize the capture device
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            m_Idle_Handler = new EventHandler(FrameGrabber);
            Application.Idle += m_Idle_Handler;

            //Load haarcascades for face detection
            frontal_face_pattern = new HaarCascade("haarcascade_frontalface_default.xml");
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
                    training_images.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    face_labels.Add(Labels[tf]);
                    recognized_people.Add(Labels[tf]);
                    recognized_faces.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    recognized_flags.Add(false);
                }
                Train();

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            m_Terminal.Express("Vision started.", Expression_Types.Information);
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            current_frame = grabber.QueryFrame().Resize(640, 480, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = current_frame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          frontal_face_pattern,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));
            if (detected_people != facesDetected[0].Length)
            {
                detected_people = facesDetected[0].Length;
                if (detected_people != 0)
                {
                    m_Terminal.Express(detected_people + " people detected.",Expression_Types.Information);
                }
            }
            //Action for each element detected

            foreach (MCvAvgComp f in facesDetected[0])
            {

                Recognize(f);
            }

            //If We dont detect faces we try to track them using their lst positions
            for (int i = 0; i < last_positions.Count; i++)
            {
                if (recognized_flags[i] == false)
                {
                    //Need to improve performance on Track
                    //Track(last_positions[i],i);
                }
            }

            if (form_vision != null)
            {
                form_vision.Set_Current_Frame(current_frame);
                form_vision.Set_Faces(detected_faces);
            }


            detected_faces.Clear();
            for (int i = 0; i < recognized_flags.Count; i++)
                recognized_flags[i] = false;
        }

        internal void Save_Data()
        {
            //Write the number of triained faces in a file text for further load
            File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", training_images.ToArray().Length.ToString() + "%");

            //Write the labels of triained faces in a file text for further load
            for (int i = 1; i < training_images.ToArray().Length + 1; i++)
            {
                training_images.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", recognized_people[i - 1] + "%");
            }
            Train();
        }

        void Recognize(MCvAvgComp f)
        {
            result = current_frame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //draw the face detected in the 0th (gray) channel with blue color
            current_frame.Draw(f.rect, new Bgr(Color.Red), 2);


            if (training_images.ToArray().Length != 0)
            {


                float[] distances = recognizer.GetEigenDistances(result);
                name = recognizer.Recognize(result);
                if (name == null || name == "")
                {
                    name = "someone_" + unknown_people;
                    unknown_people++;
                    MessageBox.Show("Unknown person detected.");
                }
                if (!recognized_people.Exists(n => n == name))
                {
                    recognized_people.Add(name);
                    recognized_faces.Add(result);
                    last_positions.Add(f.rect);
                    recognized_flags.Add(true);
                    m_Terminal.Express("Person recognized: " + name, Expression_Types.Information);
                }
                else
                {
                    int index = recognized_people.IndexOf(name);
                    recognized_faces[index] = result;
                   // Vision.voice.Speak("Hi " + name + "!, good to see you again.");
                    recognized_flags[index] = true;
                }
                detected_faces.Add(result);
                //Draw the label for each face detected and recognized
                current_frame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));



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
                        training_images.Add(result);
                        face_labels.Add(name);
                        recognized_people.Add(name);
                        Save_Data();

                    }
                }


            }
            else
            {
                training_images.Add(result);
                face_labels.Add("Unknown");
                recognized_people.Add("Unknown");
                Save_Data();

            }
            if (unknown_people > 0)
            {
                m_Terminal.Express(unknown_people + " unknown people detected.",Expression_Types.Information);
            }
        }

        void Track(Rectangle rect, int index)
        {
            int pixels_move = 5;
            Rectangle tmp = rect;
            tmp.X += pixels_move;
            Image<Gray, byte> pos_1 = current_frame.Copy(tmp).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            tmp = rect;
            tmp.X -= pixels_move;
            Image<Gray, byte> pos_2 = current_frame.Copy(tmp).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            tmp = rect;
            tmp.Y += pixels_move;
            Image<Gray, byte> pos_3 = current_frame.Copy(tmp).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            tmp = rect;
            tmp.Y -= pixels_move;
            Image<Gray, byte> pos_4 = current_frame.Copy(tmp).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);





            if (training_images.ToArray().Length != 0)
            {
                name = recognized_people[index];

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
                    detected_faces.Add(result);
                    current_frame.Draw(name, ref font, new Point(rect.X - 2, rect.Y - 2), new Bgr(Color.LightGreen));
                    current_frame.Draw(rect, new Bgr(Color.Yellow), 2);
                    last_positions[index] = rect;

                    if (min_distance > 1700)
                    {
                        training_images.Add(result);
                        face_labels.Add(name);
                        recognized_people.Add(name);
                        Save_Data();

                    }
                }


            }
            if (unknown_people > 0)
            {
                m_Terminal.Express(unknown_people + " unknown people detected.", Expression_Types.Information);
            }
        }

        void Train()
        {
            recognizer = new EigenObjectRecognizer(
                       training_images.ToArray(),
                       recognized_people.ToArray(),
                       3500,
                       ref termCrit);
        }

        internal void Show_Vision(bool show)
        {
            if (show == true)
            {
                form_vision = new Vision_Full_Form();
                form_vision.Show();
            }
            else
            {
                form_vision.Close();
                form_vision.Dispose();
                form_vision = null;
            }
        }
        
    }
}

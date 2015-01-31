class ListElementsController < ApplicationController
  before_action :set_list_element, only: [:show, :edit, :update, :destroy]

  # GET /list_elements
  # GET /list_elements.json
  def index
    @list_elements = ListElement.all
  end

  # GET /list_elements/1
  # GET /list_elements/1.json
  def show
  end

  # GET /list_elements/new
  def new
    @list_element = ListElement.new
  end

  # GET /list_elements/1/edit
  def edit
  end

  # POST /list_elements
  # POST /list_elements.json
  def create
    @list_element = ListElement.new(list_element_params)

    respond_to do |format|
      if @list_element.save
        format.html { redirect_to @list_element, notice: 'List element was successfully created.' }
        format.json { render :show, status: :created, location: @list_element }
      else
        format.html { render :new }
        format.json { render json: @list_element.errors, status: :unprocessable_entity }
      end
    end
  end

  # PATCH/PUT /list_elements/1
  # PATCH/PUT /list_elements/1.json
  def update
    respond_to do |format|
      if @list_element.update(list_element_params)
        format.html { redirect_to @list_element, notice: 'List element was successfully updated.' }
        format.json { render :show, status: :ok, location: @list_element }
      else
        format.html { render :edit }
        format.json { render json: @list_element.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /list_elements/1
  # DELETE /list_elements/1.json
  def destroy
    @list_element.destroy
    respond_to do |format|
      format.html { redirect_to list_elements_url, notice: 'List element was successfully destroyed.' }
      format.json { head :no_content }
    end
  end

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_list_element
      @list_element = ListElement.find(params[:id])
    end

    # Never trust parameters from the scary internet, only allow the white list through.
    def list_element_params
      params.require(:list_element).permit(:name, :description)
    end
end

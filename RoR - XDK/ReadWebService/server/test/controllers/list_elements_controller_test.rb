require 'test_helper'

class ListElementsControllerTest < ActionController::TestCase
  setup do
    @list_element = list_elements(:one)
  end

  test "should get index" do
    get :index
    assert_response :success
    assert_not_nil assigns(:list_elements)
  end

  test "should get new" do
    get :new
    assert_response :success
  end

  test "should create list_element" do
    assert_difference('ListElement.count') do
      post :create, list_element: { description: @list_element.description, name: @list_element.name }
    end

    assert_redirected_to list_element_path(assigns(:list_element))
  end

  test "should show list_element" do
    get :show, id: @list_element
    assert_response :success
  end

  test "should get edit" do
    get :edit, id: @list_element
    assert_response :success
  end

  test "should update list_element" do
    patch :update, id: @list_element, list_element: { description: @list_element.description, name: @list_element.name }
    assert_redirected_to list_element_path(assigns(:list_element))
  end

  test "should destroy list_element" do
    assert_difference('ListElement.count', -1) do
      delete :destroy, id: @list_element
    end

    assert_redirected_to list_elements_path
  end
end

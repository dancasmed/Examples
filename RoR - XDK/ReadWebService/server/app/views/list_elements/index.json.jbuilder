json.array!(@list_elements) do |list_element|
  json.extract! list_element, :id, :name, :description
  json.url list_element_url(list_element, format: :json)
end

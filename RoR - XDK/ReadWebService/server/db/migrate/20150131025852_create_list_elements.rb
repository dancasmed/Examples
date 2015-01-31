class CreateListElements < ActiveRecord::Migration
  def change
    create_table :list_elements do |t|
      t.string :name
      t.text :description

      t.timestamps
    end
  end
end

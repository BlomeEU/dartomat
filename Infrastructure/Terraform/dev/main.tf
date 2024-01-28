resource "azurerm_resource_group" "resource_group" {
  name = "dartomat-dev"
  location = var.location
}

resource "azurerm_storage_account" "storage_account" {
  name = "dartomattoragedev"
  location = azurerm_resource_group.resource_group.location
  resource_group_name = azurerm_resource_group.resource_group.name
  account_tier = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_storage_table" "table_storage" {
  name = "dartomattablestoragedev"
  storage_account_name = azurerm_storage_account.storage_account.name
}

resource "azurerm_application_insights" "application_insights" {
  name = "dartomat-appinsights-dev"
  location = azurerm_resource_group.resource_group.location
  resource_group_name = azurerm_resource_group.resource_group.name
  application_type = "web"
}

resource "azurerm_service_plan" "functions_serviceplan" {
  name = "dartomat-serviceplan-dev"
  location = azurerm_resource_group.resource_group.location
  resource_group_name = azurerm_resource_group.resource_group.name
  os_type = "Linux"
  sku_name = "B1"
}

resource "azurerm_linux_function_app" "function-app" {
  name = "dartomat-function-dev"
  location = azurerm_resource_group.resource_group.location
  resource_group_name = azurerm_resource_group.resource_group.name
  service_plan_id = azurerm_service_plan.functions_serviceplan.id
  storage_account_name = azurerm_storage_account.storage_account.name
  site_config {
    
  }
}

resource "azuread_application_registration" "app_registration" {
  display_name = "dartomat-dev"
  description = "The Dartomat Dev application"
}
resource "azurerm_resource_group" "resource_group" {
  name = "dartomat-shared-dev"
  location = "westeurope"
}

resource "azurerm_aadb2c_directory" "b2c" {
  country_code = "DE"
  data_residency_location = "Europe"
  domain_name = "dartomat.onmicrosoft.com"
  display_name = "dartomat-b2c-tenant"
  resource_group_name = azurerm_resource_group.resource_group.name
  sku_name = "PremiumP1"
}
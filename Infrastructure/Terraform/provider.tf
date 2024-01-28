terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = "3.89.0"
    }
  }
  backend "azurerm" {
      resource_group_name  = "tfstate"
      storage_account_name = "eublometfstae"
      container_name       = "dartomat-tfstate"
      key                  = "terraform.tfstate"
  }
}

provider "azurerm" {
  # Configuration options
  subscription_id = "dc5d0555-d97b-4c96-90ca-0e1c4dbb9b77"
  features {
    
  }
}
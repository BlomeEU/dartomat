module "dev-environment" {
  source = "./dev"
  location = "westeurope"
}

module "shared-environment" {
  source = "./shared"
}
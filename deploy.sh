#!/bin/bash
# curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash

# CHECK1: Do you have an Azure subscription with access to the OpenAI?
# CHECK2: Do you know in which regions OpenAI is available?

export region=westeurope
export rgname=oai2403brg
export oainame=oai2403b
export depname=oai2403bdep

az login --use-device-code
#az account list -o table
#az account set --subscription <guid>

az group create --name $rgname --location $region

az cognitiveservices account create --name $oainame --resource-group $rgname --location $region --kind OpenAI --sku s0 

az cognitiveservices account deployment create --name $oainame --resource-group  $rgname --deployment-name $depname --model-name gpt-35-turbo --model-version "0301" --model-format OpenAI --sku-capacity "1" --sku-name "Standard"

# Client app
#dotnet new console
#dotnet add package microsoft.semantickernel
#draw the rest of the owl... :-)

#export depname=$depname
export endpoint=https://westeurope.api.cognitive.microsoft.com/
export apikey=<api-key do not save here>

dotnet run

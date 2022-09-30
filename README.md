# Famini Site Scraper
Mini .NET App to fetch all the images from the old family photo album.

To make things a bit more interesting, I'm gonna work on this with Github Codespaces and only run the finished exe in the end.

Codespace secrets to set up:

 - FAMINI_URL
 - FAMINI_PASSWORD

The pictures are in a private folder, and furthermore they're scaled automatically, so I wanna get the actual originals, which I can fortunately get
by following the data-href attribute of the parent link.

## Creating the Azure Context
Since I will want to be able to bill the use of this account separately, I will set up a new Azure Subscription

 1) Create New Billing Profile
 2) Create A New Azure Active Directory (ensure the correct Region)
 3) Switch back to default directory
 4) Create Subscription using the created directory and billing profile
 5) Switch to the created directory


## Storing the images in blobs
After we have scraped the images, the goal is to store them in Azure Blob Storage. We use a second class, Azure Blob uploader for that.

To prepare for this, run the following in Azure Cloud Shell (from your new directory, after having created the initial resource group famini-rg):

    az config set defaults.location=switzerlandnorth
    az storage account create -n faministorageaccount -g famini-rg --sku Standard_LRS

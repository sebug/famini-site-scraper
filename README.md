# Famini Site Scraper
Mini .NET App to fetch all the images from the old family photo album.

To make things a bit more interesting, I'm gonna work on this with Github Codespaces and only run the finished exe in the end.

Codespace secrets to set up:

 - FAMINI_URL
 - FAMINI_PASSWORD

The pictures are in a private folder, and furthermore they're scaled automatically, so I wanna get the actual originals, which I can fortunately get
by following the data-href attribute of the parent link.

## Storing the images in blobs
After we have scraped the images, the goal is to store them in Azure Blob Storage. We use a second class, Azure Blob uploader for that.

To prepare for this, run the following in Azure Cloud Shell:

    
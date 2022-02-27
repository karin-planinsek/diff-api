# diff-api

This repository contains a .NET 6 solution with three projects:
 - DiffApi
 - DiffApi.Tests
 - DiffApi.IntegrationTests

The main project is DiffApi. It is basically a REST API, which has three endpoints:
- /v1/diff/{id} : this endpoint returns diff details between data on the left and right endpoint. Diff details are returned only if the data on right and left endpoint have the same length, but not the same content. Before we can check the diffs on this endpont, data has to be posted on both left and right endpoint
- /v1/diff/{id}/left : endpoint for creating and updating left data
- /v1/diff{id}/right : endpoint for creating and updating right data

DiffApi project also integrates Swagger when it is in development mode, therefore it displays Swagger in a browser window upon start up and the functionality can also be tested there.

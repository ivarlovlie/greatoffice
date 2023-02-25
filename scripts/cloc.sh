#!/bin/bash
cloc --exclude-dir=bin,obj,build,node_modules,bootstrap,wwwroot --exclude-ext=json,xml ..

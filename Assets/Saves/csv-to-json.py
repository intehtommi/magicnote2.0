
import os
import pandas as pd
import json
import numpy as np
###########################################################################################################
# This python file aims to decode csv question data to json question data.                                #
# Users are required to place their csv(UTF-8 encoding) of their question data in the same directory.     #
###########################################################################################################

for curDir, dirs, files in os.walk("./"):
    for file in files:
        if file.endswith(".csv"):
            df = pd.read_csv(file)
            df = df[4:].dropna(axis='index', how='all', subset = ['作成者：'])
            qlist = df.to_numpy()
            exportlist = {
                     "listTitle": file,
                     "question": qlist[:,3].tolist(),
                     "correct": qlist[:,4].tolist(),
                     "corCountSave": [0 for x in range(len(qlist[:,4]))]}
            jsonlist = json.dumps(exportlist)
            file = os.path.splitext(os.path.basename(file))[0]
            with open(file+".json", mode = "wt", encoding = 'utf-8') as writefile:
                json.dump(exportlist, writefile, ensure_ascii=False, indent=2)



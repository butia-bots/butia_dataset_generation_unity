# butia_dataset_generation_unity package

## 1. Description

This repository provides the Unity Editor project for the synthetic computer vision dataset generation tools used by our team at LARC 2021. There is also a Jupyter notebook for data exploration of the datasets generated with the tool.

___
## 2. Requirements

You will need:
- [Unity Editor](https://unity.com/download)

___
## 3. Open Unity Project

Install the latest Unity Editor LTS release, and open the project at the ButiaSimulation folder.

___
## 4. Generate Dataset

Once the Unity Editor has finished loading, navigate, inside the Editor, to the folder "Scenes" and open the scene named "ButiaSimulation" on the Scene View. Then, hit the "play" button to start generating an object detection dataset. Once the scene has finished playing, there should be a message on the editor's console, logging the path to the generated dataset. Refer to the jupyter notebook at the root of this repository for an example of how to convert the generated dataset to the format used by the Microsoft COCO (Common Objects In Context) dataset.

___
## 5. Customize Dataset Generation Pipeline

Our generator is built on top of the [Unity Perception Package](https://github.com/Unity-Technologies/com.unity.perception). Please refer to the documentation of the Unity Perception Package for information on how to add new objects and backgrounds to the generator.


## Citation
If you find this package useful, consider citing it using:
```
@misc{butia_dataset_generation_unity,
    title={Butia Dataset Generation Unity Package},
    author={{ButiaBots}},
    howpublished={\url{https://github.com/butia-bots/butia_dataset_generation_unity/}},
    year={2022}
}
```
<p align="center"> 
  <i>If you liked this repository, please don't forget to starred it!</i>
  <img src="https://img.shields.io/github/stars/butia-bots/butia_dataset_generation_unity?style=social"/>
</p>

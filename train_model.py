
import os
os.environ["KMP_DUPLICATE_LIB_OK"] = "TRUE"
import ultralytics
from ultralytics import YOLO



def train_model():
    
    
    model_path="C:/Plant_Village/weights/yolov8m.pt"

    model=YOLO(model_path)

    results=model.train(
        epochs=150,
        data=r"C:/Plant_Village/dataset_v2/data.yaml",
        batch=8,
        imgsz=640,
        patience=30,
        dropout=0.1,
        optimizer="adamW",
        workers=4,
        device=0,
        cos_lr=True,
        amp=False,
        lr0=0.001,
        name="Plant"
    )
if __name__=="__main__":
    train_model()





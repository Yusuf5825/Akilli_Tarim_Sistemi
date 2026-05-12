import ultralytics
from ultralytics import YOLO

def predict_model():

    model_path="C:/Plant_Village/runs/detect/Plant/weights/best.pt"
    model=YOLO(model_path)

    results=model.predict(
        source="C:/Plant_Village/dataset_v2/test/images",
        save=True,
        conf=0.35,
        device=0,
        batch=32,
        project="Bitki_Tahminler",
        name="test_sonuclari"
    )
if __name__=="__main__":
    predict_model()
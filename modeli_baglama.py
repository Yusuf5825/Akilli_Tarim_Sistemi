from fastapi import FastAPI, UploadFile, File
from ultralytics import YOLO
import io
from PIL import Image

app = FastAPI()
model = YOLO(r"models/Plant/weights/best.pt") 

@app.post("/tespit-et")
async def tespit_yap(file: UploadFile = File(...)):
    content = await file.read()
    img = Image.open(io.BytesIO(content))
    results = model(img)
    
    if results[0].boxes:
        box = results[0].boxes[0]
        label = results[0].names[int(box.cls[0])] 
        
        parts = label.split("__")
        plant = parts[0]
        disease = parts[1] if len(parts) > 1 else "Saglikli"
        
        return f"{plant}___{disease}"
    
    return "Bilinmiyor___Saglikli"

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="127.0.0.1", port=8000)
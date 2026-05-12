import os

tespit_edilemeyenler_yolu = r'C:/Plant_Village/tespit_edilemeyenler'
test_images_yolu = r'C:/Plant_Village/dataset/test/images'
test_labels_yolu = r'C:/Plant_Village/dataset/test/labels'

# 1. Silinecek dosyaların listesini al (uzantısız isimler)
silinecekler = [os.path.splitext(f)[0] for f in os.listdir(tespit_edilemeyenler_yolu)]

print(f"{len(silinecekler)} adet dosya için temizlik başlıyor...")

silinen_resim = 0
silinen_etiket = 0

for isim in silinecekler:
    
    for ext in ['.jpg', '.png', '.jpeg']:
        resim_yolu = os.path.join(test_images_yolu, isim + ext)
        if os.path.exists(resim_yolu):
            os.remove(resim_yolu)
            silinen_resim += 1
            
    
    etiket_yolu = os.path.join(test_labels_yolu, isim + '.txt')
    if os.path.exists(etiket_yolu):
        os.remove(etiket_yolu)
        silinen_etiket += 1

print("-" * 30)
print(f"TEMİZLİK TAMAMLANDI!")
print(f"Silinen Resim: {silinen_resim}")
print(f"Silinen Etiket: {silinen_etiket}")
print("Artık test verinde 'data leakage' riski kalmadı.")
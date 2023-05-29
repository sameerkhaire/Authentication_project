import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FileService } from '../../features/public/Services/file.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: [
  ]
})
export class DashboardComponent implements OnInit{
  fileToUpload: any;
  constructor(private files:FileService) {
    
  }
  ngOnInit(): void {
  }

  saveData(){
    const formData = new FormData();
    formData.append('file', this.fileToUpload, this.fileToUpload.name);
    this.files.UploadFile(formData).subscribe(res => {
      if (res.status == 200) {
        let filePath = res.body.dbPath;
        if (filePath != '') {
          // this.courseForm.patchValue({ imageUrl: filePath });
          console.log(filePath)
        }
      }
    });
  }
  changeFile(files: any) {
    if (files.length == 0)
      return;
    else
      this.fileToUpload = <File>files[0];
  }
}

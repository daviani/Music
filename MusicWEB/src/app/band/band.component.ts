import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../api/api.service';

@Component({
  selector: 'app-band',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './band.component.html',
  styleUrl: './band.component.css'
})
export class BandComponent {

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getAllBands().subscribe((data) => {
      console.log('dataaaaaaaa',data);
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { SEOService } from '../../../services/seo/seo.service';

@Component({
  templateUrl: './ethics.component.html',
  styleUrls: ['./ethics.component.scss']
})
export class EthicsComponent implements OnInit {

  constructor(
    private seoService: SEOService
  ) { }

  ngOnInit() {
    this.seoService.setTitle('Code of Ethics');
    this.seoService.setDescription('Our code of business ethics outlining how we run the project and podcast');
  }
}

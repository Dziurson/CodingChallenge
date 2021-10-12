import { Component, OnInit } from '@angular/core';
import { Score } from 'src/app/models/score';
import { ScoresService } from 'src/app/services/scores.service';

@Component({
  selector: 'scores',
  templateUrl: './scores.component.html',
  styleUrls: ['./scores.component.scss']
})
export class ScoresComponent implements OnInit {

  public scores: Score[];

  constructor(private scoresService: ScoresService) { }

  ngOnInit(): void {
    this.scoresService.getTop(3).subscribe(scores => {
      this.scores = scores;
    })
  }

}

import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public movies: Movies[];
  movie: Movies;

  constructor(private http: HttpClient, private modalService: NgbModal) {

    this.movie = new Movies();

    http.get<Movies[]>('http://localhost:6543/api/v1/movies/api/Movies/list/movie').subscribe(result => {

      this.movies = result;
      console.log(this.movies);
    }, error => console.error(error));
  }

  openNewMovie(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {

    }, (reason) => {

    });
  }

  editNewMovie(content, data: Movies) {

    this.movie = data;
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {

    }, (reason) => {

    });
  }

  openSellTicket(ticketSold) {
    this.modalService.open(ticketSold, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {

    }, (reason) => {

    });
  }

  movieSave() {

    let body = JSON.stringify(this.movie);

    console.log(body);

    let headers = new HttpHeaders();
    headers.append('Content-Type','application/json');

    this.http.post<any>('http://localhost:6543/api/v1/movies/api/Movies/save/createMovie', body,{headers : headers}).subscribe(result => {
      console.log(result);
    }, error => console.error(error));

    this.modalService.dismissAll();
  }

  movieUpdate() {

  }

  sellTicket() {

  }

}

class Movies {
  id;
  name: string;
  director: string;
  budget: number;
}

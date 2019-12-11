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
  ticket: Ticket;

  constructor(private http: HttpClient, private modalService: NgbModal) {

    this.movie = new Movies();
    this.ticket = new Ticket();
    this.getList();
  }

  getList() {
    this.http.get<Movies[]>('http://localhost:6543/api/v1/movies/api/Movies/list/movie').subscribe(result => {
      this.movies = result;
    }, error => console.error(error));
  }

  openNewMovie(content) {

    this.movie = new Movies();

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

  openSellTicket(ticketSold, data: Movies) {

    this.ticket.movieId = data.id.value;
    this.movie = data;

    this.modalService.open(ticketSold, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {

    }, (reason) => {

    });
  }

  movieSave() {

    let body = JSON.stringify(this.movie);


    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    headers = headers.append('Accept', 'application/json')

    this.http.post<any>('http://localhost:6543/api/v1/movies/api/Movies/save/createMovie', body, { headers: headers })
      .subscribe(result => {
        this.getList();
        this.modalService.dismissAll();
      }, error => console.error(error));
  }

  movieUpdate() {

    this.movie.id = this.movie.id.value;
    console.log(this.movie);

    let body = JSON.stringify(this.movie);

    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    headers = headers.append('Accept', 'application/json')

    this.http.post<any>('http://localhost:6543/api/v1/movies/api/Movies/save/updateMovie', body, { headers: headers })
      .subscribe(result => {
        this.getList();
        this.modalService.dismissAll();
      }, error => console.error(error));

  }

  sellTicket() {
    console.log(this.ticket);

    let body = JSON.stringify(this.ticket);

    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    headers = headers.append('Accept', 'application/json')

    this.http.post<any>('http://localhost:6543/api/v1/tickets/api/Ticket/save/sellTicket', body, { headers: headers })
      .subscribe(result => {
        this.getList();
        this.modalService.dismissAll();
      }, error => console.error(error));

  }

}

class Movies {
  id;
  name: string;
  director: string;
  budget: number;
}

class Ticket {
  movieId: string;
  fullName: string;
  price: number;
}

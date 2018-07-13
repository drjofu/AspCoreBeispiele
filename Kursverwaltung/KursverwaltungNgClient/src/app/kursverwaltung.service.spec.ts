import { TestBed, inject } from '@angular/core/testing';

import { KursverwaltungService } from './kursverwaltung.service';

describe('KursverwaltungService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [KursverwaltungService]
    });
  });

  it('should be created', inject([KursverwaltungService], (service: KursverwaltungService) => {
    expect(service).toBeTruthy();
  }));
});

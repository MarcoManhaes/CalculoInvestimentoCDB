
import { Component, Input, OnInit } from '@angular/core';
import { Cdb } from '../valorInvestido';
import { QuantidadeMeses } from '../quantidadeMeses';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss']
})
export class InputFields {

    @Input() Cdb :  Cdb = {
        valorBruto: 0,
        valorLiquido: 0,
        valorDesconto: 0,
    }
    
    private readonly api_base = 'http://localhost:5001/';
    
    valorInvestido: number = 0;
    quantidadeMeses: number = 0;
    valorBruto: number = 0;
    valorLiquido: number = 0;
    valorDesconto: number = 0;
  
    constructor(private http: HttpClient) { }
    
    atribuirParametros() {
        
        const valorInvestidoPreenchido = this.valorInvestido;
        const quantidadeMesesPreenchido = this.quantidadeMeses;
   
        const apiUrl = this.api_base + `calcular?valor=${this.valorInvestido}&prazoMeses=${this.quantidadeMeses}`;
     
        debugger;
        var teste = this.http.get<Cdb>(apiUrl);
     
        this.http.get<Cdb>(apiUrl).subscribe(
        (response) => {
            debugger;
            this.valorBruto = response.valorBruto;
            this.valorLiquido = response.valorLiquido;
            this.valorDesconto = response.valorDesconto;
            
            console.log('Resposta da requisição:', response);
        },
        (error) => {
            console.error('Erro na requisição:', error);
        }
    );
  }
}
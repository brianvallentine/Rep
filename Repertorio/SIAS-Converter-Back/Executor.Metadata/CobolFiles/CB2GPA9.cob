       IDENTIFICATION DIVISION.                                                 
       PROGRAM-ID. AC10P013.                                                    
                                                                                
      *---------------------*                                                   
       ENVIRONMENT DIVISION.                                                    
      *---------------------*                                                   
                                                                                
      *---------------------*                                                   
       CONFIGURATION SECTION.                                                   
      *---------------------*                                                   
                                                                                
      *-------------*                                                           
       SPECIAL-NAMES.                                                           
      *-------------*                                                           
           DECIMAL-POINT IS COMMA.                                              
                                                                                
      *--------------------*                                                    
       INPUT-OUTPUT SECTION.                                                    
      *--------------------*                                                    
                                                                                
      *-------------*                                                           
       DATA DIVISION.                                                           
      *-------------*                                                           
      *                                                                         
      *-----------------------*                                                 
       WORKING-STORAGE SECTION.                                                 
      *-----------------------*                                                 
             
      *----------------------------------------------------------------*        
      *- VARIAVEIS AUXILIARES                                          *        
      *----------------------------------------------------------------*        
                                                                                     
      *>    05  LK-TIP-CALC                        PIC 9(001) VALUE ZEROS .            
      *>    05  LK-NUM-APOL                        PIC 9(001) VALUE ZEROS .           
      *>    05  LK-NRENDOS                         PIC 9(001) VALUE ZEROS .   
      *>    05  LK-DTINIVIG                     OCCURS      2000   TIMES               
      *>                                        INDEXED      BY    WIND.          
      *>        10      WTABG-CODPRODU             PIC S9(004)        COMP.               
      *>            15  WTABG-OCORRETIP         OCCURS       003   TIMES       
      *>                                        INDEXED      BY    WIND2.     
      *>                25    WTABG-TIPO  PIC  X(001).                 

      *>   77  LK-TIP-CALC                        PIC X(254).
           77  NUM-APOLICE                        PIC X(254).
           77  TIPSGU                             PIC X(254).
           77  MODALIDA                           PIC X(254).
           77  ORGAO                              PIC X(254).
           77  RAMO                               PIC X(254).
           77  NUM-APOL-ANTERIOR                  PIC X(254).
           77  NOME                               PIC X(254).
           77  CGCCPF                             PIC X(254).
           77  TPPESSOA                           PIC X(254).
           77  PODPUBL                            PIC X(254).
           77  DATA-SORTEIO                       PIC X(254).
           77  NUM-ATA                            PIC X(254).
           77  ANO-ATA                            PIC X(254).
           77  TPCOSCED                           PIC X(254).
           77  QTCOSSEG                           PIC X(254).
           77  PCDESCON                           PIC X(254).
           77  PCIOCC                             PIC X(254).
           77  TIPCALC                            PIC X(254).
           77  TIPAPO                             PIC X(254).
           77  IDEMAN                             PIC X(254).
           77  PCTCED                             PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
    NUM-APOLICE
         TIPSGU
       MODALIDA
          ORGAO
           RAMO
NUM-APOL-ANTERIOR
           NOME
         CGCCPF
       TPPESSOA
        PODPUBL
   DATA-SORTEIO
        NUM-ATA
        ANO-ATA
       TPCOSCED
       QTCOSSEG
       PCDESCON
         PCIOCC
        TIPCALC
         TIPAPO
         IDEMAN
         PCTCED.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR SELECT TIPSGU, NUM_APOLICE, MODALIDA, ORGAO, RAMO, NUM_APOL_ANTERIOR, NOME, CGCCPF, TPPESSOA, PODPUBL, DATA_SORTEIO, NUM_ATA, ANO_ATA, TPCOSCED, QTCOSSEG, PCDESCON, PCIOCC, TIPCALC, TIPAPO, IDEMAN, PCTCED FROM seguros.v1apolice WHERE num_apolice = :NUM_APOLICE END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            

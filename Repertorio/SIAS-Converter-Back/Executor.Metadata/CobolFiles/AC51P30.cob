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
           77  IDSISTEM                           PIC X(254).
           77  CODRELAT                           PIC X(254).
           77  DATA-SOLICITACAO                   PIC X(254).
           77  CONGENER                           PIC X(254).
           77  PERI-INICIAL                       PIC X(254).
           77  PERI-FINAL                         PIC X(254).
           77  CODUSU                             PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
       IDSISTEM
       CODRELAT
DATA-SOLICITACAO
       CONGENER
   PERI-INICIAL
     PERI-FINAL
         CODUSU.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR delete from seguros.v0relatorios where idsistem = :IDSISTEM and codrelat = :CODRELAT and data_solicitacao = :DATA_SOLICITACAO and congener = :CONGENER and peri_inicial = :PERI_INICIAL and peri_final = :PERI_FINAL and codusu = :CODUSU END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            

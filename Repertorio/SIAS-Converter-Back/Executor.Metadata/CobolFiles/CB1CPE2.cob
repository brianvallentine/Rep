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
           77  TIPSGU                             PIC X(254).
           77  DTAVISO                            PIC X(254).
           77  DTMOVTO                            PIC X(254).
           77  SDOATU                             PIC X(254).
           77  SITUACAO                           PIC X(254).
           77  BCOAVISO                           PIC X(254).
           77  AGEAVISO                           PIC X(254).
           77  NRAVISO                            PIC X(254).

       
                                                                                
      *------------------*                                                      
       PROCEDURE DIVISION USING  
         TIPSGU
        DTAVISO
        DTMOVTO
         SDOATU
       SITUACAO
       BCOAVISO
       AGEAVISO
        NRAVISO.

      *------------------*                                                      
      *--------------*                                                          
       0000-PRINCIPAL.                                                          
      *--------------*                                                       
               EXEC SQL DECLARE CUR1 WITH RETURN WITH HOLD FOR UPDATE seguros.v0avisos_saldos SET TIPSGU = :TIPSGU, DTAVISO = :DTAVISO, DTMOVTO = :DTMOVTO, SDOATU = :SDOATU, situacao = :SITUACAO, TIMESTAMP = current timestamp WHERE bcoaviso = :BCOAVISO AND ageaviso = :AGEAVISO AND nraviso = :NRAVISO END-EXEC                                                              
      *    
           OPEN CUR1.	  
           STOP RUN.                                                            

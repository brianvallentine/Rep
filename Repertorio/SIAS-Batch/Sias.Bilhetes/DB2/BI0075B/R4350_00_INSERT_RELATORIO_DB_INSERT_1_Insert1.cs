using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1 : QueryBasis<R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.RELATORIOS
            VALUES ( 'BI0075B' ,
            CURRENT DATE ,
            'BI' ,
            :RELATORI-COD-RELATORIO ,
            0 ,
            0 ,
            CURRENT DATE ,
            CURRENT DATE ,
            CURRENT DATE ,
            0 ,
            0 ,
            0 ,
            0 ,
            0 ,
            0 ,
            0 ,
            0 ,
            :RELATORI-NUM-APOLICE ,
            :RELATORI-NUM-ENDOSSO ,
            0 ,
            :RELATORI-NUM-CERTIFICADO ,
            :RELATORI-NUM-TITULO ,
            0 ,
            :RELATORI-COD-OPERACAO ,
            0 ,
            0 ,
            ' ' ,
            ' ' ,
            0 ,
            0 ,
            ' ' ,
            0 ,
            0 ,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            NULL ,
            0 ,
            0 ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS VALUES ( 'BI0075B' , CURRENT DATE , 'BI' , {FieldThreatment(this.RELATORI_COD_RELATORIO)} , 0 , 0 , CURRENT DATE , CURRENT DATE , CURRENT DATE , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , {FieldThreatment(this.RELATORI_NUM_APOLICE)} , {FieldThreatment(this.RELATORI_NUM_ENDOSSO)} , 0 , {FieldThreatment(this.RELATORI_NUM_CERTIFICADO)} , {FieldThreatment(this.RELATORI_NUM_TITULO)} , 0 , {FieldThreatment(this.RELATORI_COD_OPERACAO)} , 0 , 0 , ' ' , ' ' , 0 , 0 , ' ' , 0 , 0 , ' ' , '0' , ' ' , ' ' , NULL , 0 , 0 , CURRENT TIMESTAMP)";

            return query;
        }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }
        public string RELATORI_NUM_ENDOSSO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }
        public string RELATORI_COD_OPERACAO { get; set; }

        public static void Execute(R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1 r4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1)
        {
            var ths = r4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}
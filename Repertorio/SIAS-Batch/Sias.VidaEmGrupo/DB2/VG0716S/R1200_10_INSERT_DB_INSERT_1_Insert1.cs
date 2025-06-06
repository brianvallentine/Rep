using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0716S
{
    public class R1200_10_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R1200_10_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.TITULOS_FED_CAP_VA
            ( NRTITFDCAP ,
            NUM_CERTIFICADO ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            NRSORTEIO ,
            VAL_CUSTO_TITULO ,
            NRPARCEL ,
            NRMFDCAPF ,
            SITUACAO ,
            SIT_RELAT ,
            DATA_MOVIMENTO ,
            TIMESTAMP ,
            NRMFDCAPR ,
            NRTITREN )
            VALUES
            ( :MOVFEDCA-NRTITFDCAP ,
            :TITFEDCA-NUM-CERTIFICADO ,
            :TITFEDCA-DATA-INIVIGENCIA ,
            :TITFEDCA-DATA-TERVIGENCIA ,
            :TITFEDCA-NRSORTEIO ,
            :TITFEDCA-VAL-CUSTO-TITULO ,
            0 ,
            0 ,
            '0' ,
            '1' ,
            :SISTEMAS-DATA-MOV-ABERTO ,
            CURRENT TIMESTAMP ,
            0 ,
            0 )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.TITULOS_FED_CAP_VA ( NRTITFDCAP , NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , NRSORTEIO , VAL_CUSTO_TITULO , NRPARCEL , NRMFDCAPF , SITUACAO , SIT_RELAT , DATA_MOVIMENTO , TIMESTAMP , NRMFDCAPR , NRTITREN ) VALUES ( {FieldThreatment(this.MOVFEDCA_NRTITFDCAP)} , {FieldThreatment(this.TITFEDCA_NUM_CERTIFICADO)} , {FieldThreatment(this.TITFEDCA_DATA_INIVIGENCIA)} , {FieldThreatment(this.TITFEDCA_DATA_TERVIGENCIA)} , {FieldThreatment(this.TITFEDCA_NRSORTEIO)} , {FieldThreatment(this.TITFEDCA_VAL_CUSTO_TITULO)} , 0 , 0 , '0' , '1' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , CURRENT TIMESTAMP , 0 , 0 )";

            return query;
        }
        public string MOVFEDCA_NRTITFDCAP { get; set; }
        public string TITFEDCA_NUM_CERTIFICADO { get; set; }
        public string TITFEDCA_DATA_INIVIGENCIA { get; set; }
        public string TITFEDCA_DATA_TERVIGENCIA { get; set; }
        public string TITFEDCA_NRSORTEIO { get; set; }
        public string TITFEDCA_VAL_CUSTO_TITULO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R1200_10_INSERT_DB_INSERT_1_Insert1 r1200_10_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r1200_10_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_10_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}
using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0074B
{
    public class R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1 : QueryBasis<R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.AVISO_CREDITO
            (BCO_AVISO ,
            AGE_AVISO ,
            NUM_AVISO_CREDITO ,
            NUM_SEQUENCIA ,
            DATA_MOVIMENTO ,
            COD_OPERACAO ,
            TIPO_AVISO ,
            DATA_AVISO ,
            VAL_IOCC ,
            VAL_DESPESA ,
            PRM_COSSEGURO_CED ,
            PRM_LIQUIDO ,
            PRM_TOTAL ,
            SIT_CONTABIL ,
            COD_EMPRESA ,
            TIMESTAMP ,
            ORIGEM_AVISO ,
            VAL_ADIANTAMENTO ,
            STA_DEPOSITO_TER)
            VALUES
            (:AVISOCRE-BCO-AVISO ,
            :AVISOCRE-AGE-AVISO ,
            :AVISOCRE-NUM-AVISO-CREDITO ,
            :AVISOCRE-NUM-SEQUENCIA ,
            :AVISOCRE-DATA-MOVIMENTO ,
            :AVISOCRE-COD-OPERACAO ,
            :AVISOCRE-TIPO-AVISO ,
            :AVISOCRE-DATA-AVISO ,
            :AVISOCRE-VAL-IOCC ,
            :AVISOCRE-VAL-DESPESA ,
            :AVISOCRE-PRM-COSSEGURO-CED ,
            :AVISOCRE-PRM-LIQUIDO ,
            :AVISOCRE-PRM-TOTAL ,
            :AVISOCRE-SIT-CONTABIL ,
            :AVISOCRE-COD-EMPRESA ,
            CURRENT TIMESTAMP ,
            :AVISOCRE-ORIGEM-AVISO ,
            :AVISOCRE-VAL-ADIANTAMENTO ,
            :AVISOCRE-STA-DEPOSITO-TER)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.AVISO_CREDITO (BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , NUM_SEQUENCIA , DATA_MOVIMENTO , COD_OPERACAO , TIPO_AVISO , DATA_AVISO , VAL_IOCC , VAL_DESPESA , PRM_COSSEGURO_CED , PRM_LIQUIDO , PRM_TOTAL , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP , ORIGEM_AVISO , VAL_ADIANTAMENTO , STA_DEPOSITO_TER) VALUES ({FieldThreatment(this.AVISOCRE_BCO_AVISO)} , {FieldThreatment(this.AVISOCRE_AGE_AVISO)} , {FieldThreatment(this.AVISOCRE_NUM_AVISO_CREDITO)} , {FieldThreatment(this.AVISOCRE_NUM_SEQUENCIA)} , {FieldThreatment(this.AVISOCRE_DATA_MOVIMENTO)} , {FieldThreatment(this.AVISOCRE_COD_OPERACAO)} , {FieldThreatment(this.AVISOCRE_TIPO_AVISO)} , {FieldThreatment(this.AVISOCRE_DATA_AVISO)} , {FieldThreatment(this.AVISOCRE_VAL_IOCC)} , {FieldThreatment(this.AVISOCRE_VAL_DESPESA)} , {FieldThreatment(this.AVISOCRE_PRM_COSSEGURO_CED)} , {FieldThreatment(this.AVISOCRE_PRM_LIQUIDO)} , {FieldThreatment(this.AVISOCRE_PRM_TOTAL)} , {FieldThreatment(this.AVISOCRE_SIT_CONTABIL)} , {FieldThreatment(this.AVISOCRE_COD_EMPRESA)} , CURRENT TIMESTAMP , {FieldThreatment(this.AVISOCRE_ORIGEM_AVISO)} , {FieldThreatment(this.AVISOCRE_VAL_ADIANTAMENTO)} , {FieldThreatment(this.AVISOCRE_STA_DEPOSITO_TER)})";

            return query;
        }
        public string AVISOCRE_BCO_AVISO { get; set; }
        public string AVISOCRE_AGE_AVISO { get; set; }
        public string AVISOCRE_NUM_AVISO_CREDITO { get; set; }
        public string AVISOCRE_NUM_SEQUENCIA { get; set; }
        public string AVISOCRE_DATA_MOVIMENTO { get; set; }
        public string AVISOCRE_COD_OPERACAO { get; set; }
        public string AVISOCRE_TIPO_AVISO { get; set; }
        public string AVISOCRE_DATA_AVISO { get; set; }
        public string AVISOCRE_VAL_IOCC { get; set; }
        public string AVISOCRE_VAL_DESPESA { get; set; }
        public string AVISOCRE_PRM_COSSEGURO_CED { get; set; }
        public string AVISOCRE_PRM_LIQUIDO { get; set; }
        public string AVISOCRE_PRM_TOTAL { get; set; }
        public string AVISOCRE_SIT_CONTABIL { get; set; }
        public string AVISOCRE_COD_EMPRESA { get; set; }
        public string AVISOCRE_ORIGEM_AVISO { get; set; }
        public string AVISOCRE_VAL_ADIANTAMENTO { get; set; }
        public string AVISOCRE_STA_DEPOSITO_TER { get; set; }

        public static void Execute(R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1 r5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1)
        {
            var ths = r5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5100_00_INSERT_AVISOCRE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}
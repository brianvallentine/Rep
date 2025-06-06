using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1 : QueryBasis<P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CB_APOLICE_VIGPROP
            ( NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,DATA_MOVIMENTO
            ,DATA_VENCIMENTO
            ,PREMIO_TOTAL_PAGO
            ,PREMIO_TOTAL_DEV
            ,QTD_DIAS_COBERTOS
            ,DATA_FIM_VIG_PROP
            ,DATA_CANCELAMENTO
            ,IDTAB_SITUACAO
            ,SITUACAO
            ,TIMESTAMP
            ,DATA_MALA_VIG_PROP
            ,DATA_MALA_CANCEL
            )
            VALUES
            (:CBAPOVIG-NUM-APOLICE
            ,:CBAPOVIG-NUM-ENDOSSO
            ,:CBAPOVIG-NUM-PARCELA
            ,:CBAPOVIG-DATA-MOVIMENTO
            ,:CBAPOVIG-DATA-VENCIMENTO
            ,:CBAPOVIG-PREMIO-TOTAL-PAGO
            ,:CBAPOVIG-PREMIO-TOTAL-DEV
            ,:CBAPOVIG-QTD-DIAS-COBERTOS
            ,:CBAPOVIG-DATA-FIM-VIG-PROP
            ,:CBAPOVIG-DATA-CANCELAMENTO
            ,:CBAPOVIG-IDTAB-SITUACAO
            ,:CBAPOVIG-SITUACAO
            , CURRENT TIMESTAMP
            , NULL
            , NULL
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CB_APOLICE_VIGPROP ( NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DATA_MOVIMENTO ,DATA_VENCIMENTO ,PREMIO_TOTAL_PAGO ,PREMIO_TOTAL_DEV ,QTD_DIAS_COBERTOS ,DATA_FIM_VIG_PROP ,DATA_CANCELAMENTO ,IDTAB_SITUACAO ,SITUACAO ,TIMESTAMP ,DATA_MALA_VIG_PROP ,DATA_MALA_CANCEL ) VALUES ({FieldThreatment(this.CBAPOVIG_NUM_APOLICE)} ,{FieldThreatment(this.CBAPOVIG_NUM_ENDOSSO)} ,{FieldThreatment(this.CBAPOVIG_NUM_PARCELA)} ,{FieldThreatment(this.CBAPOVIG_DATA_MOVIMENTO)} ,{FieldThreatment(this.CBAPOVIG_DATA_VENCIMENTO)} ,{FieldThreatment(this.CBAPOVIG_PREMIO_TOTAL_PAGO)} ,{FieldThreatment(this.CBAPOVIG_PREMIO_TOTAL_DEV)} ,{FieldThreatment(this.CBAPOVIG_QTD_DIAS_COBERTOS)} ,{FieldThreatment(this.CBAPOVIG_DATA_FIM_VIG_PROP)} ,{FieldThreatment(this.CBAPOVIG_DATA_CANCELAMENTO)} ,{FieldThreatment(this.CBAPOVIG_IDTAB_SITUACAO)} ,{FieldThreatment(this.CBAPOVIG_SITUACAO)} , CURRENT TIMESTAMP , NULL , NULL )";

            return query;
        }
        public string CBAPOVIG_NUM_APOLICE { get; set; }
        public string CBAPOVIG_NUM_ENDOSSO { get; set; }
        public string CBAPOVIG_NUM_PARCELA { get; set; }
        public string CBAPOVIG_DATA_MOVIMENTO { get; set; }
        public string CBAPOVIG_DATA_VENCIMENTO { get; set; }
        public string CBAPOVIG_PREMIO_TOTAL_PAGO { get; set; }
        public string CBAPOVIG_PREMIO_TOTAL_DEV { get; set; }
        public string CBAPOVIG_QTD_DIAS_COBERTOS { get; set; }
        public string CBAPOVIG_DATA_FIM_VIG_PROP { get; set; }
        public string CBAPOVIG_DATA_CANCELAMENTO { get; set; }
        public string CBAPOVIG_IDTAB_SITUACAO { get; set; }
        public string CBAPOVIG_SITUACAO { get; set; }

        public static void Execute(P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1 p2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1)
        {
            var ths = p2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}
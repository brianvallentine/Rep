using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1 : QueryBasis<R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CB_MALA_PARCATRASO
            ( NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,DATA_MOVIMENTO
            ,DATA_VENC_CONTR
            ,IDTAB_SITUACAO
            ,SITUACAO
            ,NUM_TITULO
            ,DATA_VENCIMENTO
            ,PREMIO_TOTAL
            ,VALOR_ACRESCIMO
            ,VALOR_TARIFA
            ,VALOR_VISTORIA
            ,DATA_ENVIO
            ,TIMESTAMP
            ,DTA_VENCIMENTO_AR
            )
            VALUES
            (:CBMALPAR-NUM-APOLICE
            ,:CBMALPAR-NUM-ENDOSSO
            ,:CBMALPAR-NUM-PARCELA
            ,:CBMALPAR-DATA-MOVIMENTO
            ,:CBMALPAR-DATA-VENC-CONTR
            ,:CBMALPAR-IDTAB-SITUACAO
            ,:CBMALPAR-SITUACAO
            ,:CBMALPAR-NUM-TITULO:VIND-NUM-TITULO
            ,:CBMALPAR-DATA-VENCIMENTO:VIND-DATA-VENCIMENTO
            ,:CBMALPAR-PREMIO-TOTAL:VIND-PREMIO-TOTAL
            ,:CBMALPAR-VALOR-ACRESCIMO:VIND-VALOR-ACRESCIMO
            ,:CBMALPAR-VALOR-TARIFA:VIND-VALOR-TARIFA
            ,:CBMALPAR-VALOR-VISTORIA:VIND-VALOR-VISTORIA
            ,:CBMALPAR-DATA-ENVIO:VIND-DATA-ENVIO
            , CURRENT TIMESTAMP
            ,:CBMALPAR-DTA-VENCIMENTO-AR:VIND-DTA-VENCTO-AR
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CB_MALA_PARCATRASO ( NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DATA_MOVIMENTO ,DATA_VENC_CONTR ,IDTAB_SITUACAO ,SITUACAO ,NUM_TITULO ,DATA_VENCIMENTO ,PREMIO_TOTAL ,VALOR_ACRESCIMO ,VALOR_TARIFA ,VALOR_VISTORIA ,DATA_ENVIO ,TIMESTAMP ,DTA_VENCIMENTO_AR ) VALUES ({FieldThreatment(this.CBMALPAR_NUM_APOLICE)} ,{FieldThreatment(this.CBMALPAR_NUM_ENDOSSO)} ,{FieldThreatment(this.CBMALPAR_NUM_PARCELA)} ,{FieldThreatment(this.CBMALPAR_DATA_MOVIMENTO)} ,{FieldThreatment(this.CBMALPAR_DATA_VENC_CONTR)} ,{FieldThreatment(this.CBMALPAR_IDTAB_SITUACAO)} ,{FieldThreatment(this.CBMALPAR_SITUACAO)} , {FieldThreatment((this.VIND_NUM_TITULO?.ToInt() == -1 ? null : this.CBMALPAR_NUM_TITULO))} , {FieldThreatment((this.VIND_DATA_VENCIMENTO?.ToInt() == -1 ? null : this.CBMALPAR_DATA_VENCIMENTO))} , {FieldThreatment((this.VIND_PREMIO_TOTAL?.ToInt() == -1 ? null : this.CBMALPAR_PREMIO_TOTAL))} , {FieldThreatment((this.VIND_VALOR_ACRESCIMO?.ToInt() == -1 ? null : this.CBMALPAR_VALOR_ACRESCIMO))} , {FieldThreatment((this.VIND_VALOR_TARIFA?.ToInt() == -1 ? null : this.CBMALPAR_VALOR_TARIFA))} , {FieldThreatment((this.VIND_VALOR_VISTORIA?.ToInt() == -1 ? null : this.CBMALPAR_VALOR_VISTORIA))} , {FieldThreatment((this.VIND_DATA_ENVIO?.ToInt() == -1 ? null : this.CBMALPAR_DATA_ENVIO))} , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_DTA_VENCTO_AR?.ToInt() == -1 ? null : this.CBMALPAR_DTA_VENCIMENTO_AR))} )";

            return query;
        }
        public string CBMALPAR_NUM_APOLICE { get; set; }
        public string CBMALPAR_NUM_ENDOSSO { get; set; }
        public string CBMALPAR_NUM_PARCELA { get; set; }
        public string CBMALPAR_DATA_MOVIMENTO { get; set; }
        public string CBMALPAR_DATA_VENC_CONTR { get; set; }
        public string CBMALPAR_IDTAB_SITUACAO { get; set; }
        public string CBMALPAR_SITUACAO { get; set; }
        public string CBMALPAR_NUM_TITULO { get; set; }
        public string VIND_NUM_TITULO { get; set; }
        public string CBMALPAR_DATA_VENCIMENTO { get; set; }
        public string VIND_DATA_VENCIMENTO { get; set; }
        public string CBMALPAR_PREMIO_TOTAL { get; set; }
        public string VIND_PREMIO_TOTAL { get; set; }
        public string CBMALPAR_VALOR_ACRESCIMO { get; set; }
        public string VIND_VALOR_ACRESCIMO { get; set; }
        public string CBMALPAR_VALOR_TARIFA { get; set; }
        public string VIND_VALOR_TARIFA { get; set; }
        public string CBMALPAR_VALOR_VISTORIA { get; set; }
        public string VIND_VALOR_VISTORIA { get; set; }
        public string CBMALPAR_DATA_ENVIO { get; set; }
        public string VIND_DATA_ENVIO { get; set; }
        public string CBMALPAR_DTA_VENCIMENTO_AR { get; set; }
        public string VIND_DTA_VENCTO_AR { get; set; }

        public static void Execute(R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1 r3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1)
        {
            var ths = r3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3500_00_INSERT_CBMALPAR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}
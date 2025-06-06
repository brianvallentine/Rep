using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1 : QueryBasis<R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL
            SELECT
            NUM_CERTIFICADO,
            :SISTEMAS-DATA-MOV-ABERTO AS DATA_INIVIGENCIA,
            '9998-12-31' AS DATA_TERVIGENCIA,
            :OPCPAGVI-OPCAO-PAGAMENTO,
            :PRODUVG-PERI-PAGAMENTO AS PERI_PAGAMENTO,
            DIA_DEBITO AS DIA_DEBITO,
            'VA0123B' COD_USUARIO, CURRENT TIMESTAMP,
            COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO,
            NUM_CONTA_DEBITO, DIG_CONTA_DEBITO,
            NUM_CARTAO_CREDITO
            FROM SEGUROS.OPCAO_PAG_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL SELECT NUM_CERTIFICADO, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} AS DATA_INIVIGENCIA, '9998-12-31' AS DATA_TERVIGENCIA, {FieldThreatment(this.OPCPAGVI_OPCAO_PAGAMENTO)}, {FieldThreatment(this.PRODUVG_PERI_PAGAMENTO)} AS PERI_PAGAMENTO, DIA_DEBITO AS DIA_DEBITO, 'VA0123B' COD_USUARIO, CURRENT TIMESTAMP, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = {FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)} AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string OPCPAGVI_OPCAO_PAGAMENTO { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1 r1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1)
        {
            var ths = r1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}
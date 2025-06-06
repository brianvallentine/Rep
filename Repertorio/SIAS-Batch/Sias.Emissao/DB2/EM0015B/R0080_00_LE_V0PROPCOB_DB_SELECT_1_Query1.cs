using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0015B
{
    public class R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1 : QueryBasis<R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FONTE,
            CODPRODU,
            NUM_MATRICULA,
            COD_AGENCIA,
            OPERACAO_CONTA,
            NUM_CONTA,
            DIG_CONTA,
            TIPO_COBRANCA,
            VALUE(COD_AGENCIA_DEB,0),
            VALUE(OPER_CONTA_DEB,0),
            VALUE(NUM_CONTA_DEB,0),
            VALUE(DIG_CONTA_DEB,0),
            VALUE(DIA_DEBITO,0),
            VALUE(NRCERTIF_AUTO, ' ' ),
            VALUE(NUM_CARTAO, 0),
            VALUE(MARGEM_COMERCIAL, 0)
            INTO
            :V0PROPC-FONTE,
            :V0PROPC-CODPRODU,
            :V0PROPC-NUM-MATRICULA,
            :V0PROPC-COD-AGENCIA,
            :V0PROPC-OPERACAO-CONTA,
            :V0PROPC-NUM-CONTA,
            :V0PROPC-DIG-CONTA,
            :V0PROPC-TIPO-COBRANCA,
            :V0PROPC-COD-AGENCIA-DEB,
            :V0PROPC-OPER-CONTA-DEB,
            :V0PROPC-NUM-CONTA-DEB,
            :V0PROPC-DIG-CONTA-DEB,
            :V0PROPC-DIA-DEBITO,
            :V0PROPC-NRCERTIF-AUTO,
            :V0PROPC-NUM-CARTAO,
            :V0PROPC-MARGEM-COMERCIAL
            FROM SEGUROS.V0PROPCOB
            WHERE NRPROPOS = :V0PROPC-NRPROPOS
            AND FONTE = :V0PROPC-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FONTE
							,
											CODPRODU
							,
											NUM_MATRICULA
							,
											COD_AGENCIA
							,
											OPERACAO_CONTA
							,
											NUM_CONTA
							,
											DIG_CONTA
							,
											TIPO_COBRANCA
							,
											VALUE(COD_AGENCIA_DEB
							,0)
							,
											VALUE(OPER_CONTA_DEB
							,0)
							,
											VALUE(NUM_CONTA_DEB
							,0)
							,
											VALUE(DIG_CONTA_DEB
							,0)
							,
											VALUE(DIA_DEBITO
							,0)
							,
											VALUE(NRCERTIF_AUTO
							, ' ' )
							,
											VALUE(NUM_CARTAO
							, 0)
							,
											VALUE(MARGEM_COMERCIAL
							, 0)
											FROM SEGUROS.V0PROPCOB
											WHERE NRPROPOS = '{this.V0PROPC_NRPROPOS}'
											AND FONTE = '{this.V0PROPC_FONTE}'";

            return query;
        }
        public string V0PROPC_FONTE { get; set; }
        public string V0PROPC_CODPRODU { get; set; }
        public string V0PROPC_NUM_MATRICULA { get; set; }
        public string V0PROPC_COD_AGENCIA { get; set; }
        public string V0PROPC_OPERACAO_CONTA { get; set; }
        public string V0PROPC_NUM_CONTA { get; set; }
        public string V0PROPC_DIG_CONTA { get; set; }
        public string V0PROPC_TIPO_COBRANCA { get; set; }
        public string V0PROPC_COD_AGENCIA_DEB { get; set; }
        public string V0PROPC_OPER_CONTA_DEB { get; set; }
        public string V0PROPC_NUM_CONTA_DEB { get; set; }
        public string V0PROPC_DIG_CONTA_DEB { get; set; }
        public string V0PROPC_DIA_DEBITO { get; set; }
        public string V0PROPC_NRCERTIF_AUTO { get; set; }
        public string V0PROPC_NUM_CARTAO { get; set; }
        public string V0PROPC_MARGEM_COMERCIAL { get; set; }
        public string V0PROPC_NRPROPOS { get; set; }

        public static R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1 Execute(R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1 r0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1)
        {
            var ths = r0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0080_00_LE_V0PROPCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROPC_FONTE = result[i++].Value?.ToString();
            dta.V0PROPC_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROPC_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.V0PROPC_COD_AGENCIA = result[i++].Value?.ToString();
            dta.V0PROPC_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.V0PROPC_NUM_CONTA = result[i++].Value?.ToString();
            dta.V0PROPC_DIG_CONTA = result[i++].Value?.ToString();
            dta.V0PROPC_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.V0PROPC_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.V0PROPC_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.V0PROPC_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.V0PROPC_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.V0PROPC_DIA_DEBITO = result[i++].Value?.ToString();
            dta.V0PROPC_NRCERTIF_AUTO = result[i++].Value?.ToString();
            dta.V0PROPC_NUM_CARTAO = result[i++].Value?.ToString();
            dta.V0PROPC_MARGEM_COMERCIAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}
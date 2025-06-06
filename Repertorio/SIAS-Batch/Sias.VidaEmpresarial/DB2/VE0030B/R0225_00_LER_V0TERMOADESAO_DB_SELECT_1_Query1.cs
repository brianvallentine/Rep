using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 : QueryBasis<R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TERMO,
            NUM_APOLICE,
            COD_SUBGRUPO,
            DATA_ADESAO,
            DATA_ADESAO + 3 MONTHS,
            COD_AGENCIA_OP,
            NUM_MATRICULA_VEN,
            CODPDTVEN,
            PCCOMVEN,
            CODPDTGER,
            PCCOMGER,
            COD_PLANO_VGAPC,
            COD_PLANO_APC,
            VAL_COMISSAO_ADIAN,
            QUANT_VIDAS,
            PERI_PAGAMENTO,
            COD_USUARIO,
            SITUACAO
            INTO :V0TERMO-NUM-TERMO,
            :V0TERMO-NUM-APOLICE,
            :V0TERMO-COD-SUBG,
            :V0TERMO-DT-ADESAO:VIND-DTADESAO,
            :V0TERMO-DTADESAO-3M:VIND-DTADESAO,
            :V0TERMO-COD-AGE-OP,
            :V0TERMO-MAT-VEN,
            :V0TERMO-CODPDTVEN,
            :V0TERMO-PCCOMVEN,
            :V0TERMO-CODPDTGER,
            :V0TERMO-PCCOMGER,
            :V0TERMO-PLANO-VGAP,
            :V0TERMO-PLANO-APC,
            :V0TERMO-VL-COMI-AD,
            :V0TERMO-QTD-VIDAS,
            :V0TERMO-PERI-PGTO,
            :V0TERMO-COD-USUR,
            :V0TERMO-SITUACAO
            FROM SEGUROS.V0TERMOADESAO
            WHERE NUM_APOLICE = :V1REL-NUM-APOL
            AND COD_SUBGRUPO = :V1REL-COD-SUBG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TERMO
							,
											NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											DATA_ADESAO
							,
											DATA_ADESAO + 3 MONTHS
							,
											COD_AGENCIA_OP
							,
											NUM_MATRICULA_VEN
							,
											CODPDTVEN
							,
											PCCOMVEN
							,
											CODPDTGER
							,
											PCCOMGER
							,
											COD_PLANO_VGAPC
							,
											COD_PLANO_APC
							,
											VAL_COMISSAO_ADIAN
							,
											QUANT_VIDAS
							,
											PERI_PAGAMENTO
							,
											COD_USUARIO
							,
											SITUACAO
											FROM SEGUROS.V0TERMOADESAO
											WHERE NUM_APOLICE = '{this.V1REL_NUM_APOL}'
											AND COD_SUBGRUPO = '{this.V1REL_COD_SUBG}'";

            return query;
        }
        public string V0TERMO_NUM_TERMO { get; set; }
        public string V0TERMO_NUM_APOLICE { get; set; }
        public string V0TERMO_COD_SUBG { get; set; }
        public string V0TERMO_DT_ADESAO { get; set; }
        public string VIND_DTADESAO { get; set; }
        public string V0TERMO_DTADESAO_3M { get; set; }
        public string V0TERMO_COD_AGE_OP { get; set; }
        public string V0TERMO_MAT_VEN { get; set; }
        public string V0TERMO_CODPDTVEN { get; set; }
        public string V0TERMO_PCCOMVEN { get; set; }
        public string V0TERMO_CODPDTGER { get; set; }
        public string V0TERMO_PCCOMGER { get; set; }
        public string V0TERMO_PLANO_VGAP { get; set; }
        public string V0TERMO_PLANO_APC { get; set; }
        public string V0TERMO_VL_COMI_AD { get; set; }
        public string V0TERMO_QTD_VIDAS { get; set; }
        public string V0TERMO_PERI_PGTO { get; set; }
        public string V0TERMO_COD_USUR { get; set; }
        public string V0TERMO_SITUACAO { get; set; }
        public string V1REL_NUM_APOL { get; set; }
        public string V1REL_COD_SUBG { get; set; }

        public static R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 Execute(R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 r0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1)
        {
            var ths = r0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0225_00_LER_V0TERMOADESAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0TERMO_NUM_TERMO = result[i++].Value?.ToString();
            dta.V0TERMO_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0TERMO_COD_SUBG = result[i++].Value?.ToString();
            dta.V0TERMO_DT_ADESAO = result[i++].Value?.ToString();
            dta.VIND_DTADESAO = string.IsNullOrWhiteSpace(dta.V0TERMO_DT_ADESAO) ? "-1" : "0";
            dta.V0TERMO_DTADESAO_3M = result[i++].Value?.ToString();
            dta.V0TERMO_COD_AGE_OP = result[i++].Value?.ToString();
            dta.V0TERMO_MAT_VEN = result[i++].Value?.ToString();
            dta.V0TERMO_CODPDTVEN = result[i++].Value?.ToString();
            dta.V0TERMO_PCCOMVEN = result[i++].Value?.ToString();
            dta.V0TERMO_CODPDTGER = result[i++].Value?.ToString();
            dta.V0TERMO_PCCOMGER = result[i++].Value?.ToString();
            dta.V0TERMO_PLANO_VGAP = result[i++].Value?.ToString();
            dta.V0TERMO_PLANO_APC = result[i++].Value?.ToString();
            dta.V0TERMO_VL_COMI_AD = result[i++].Value?.ToString();
            dta.V0TERMO_QTD_VIDAS = result[i++].Value?.ToString();
            dta.V0TERMO_PERI_PGTO = result[i++].Value?.ToString();
            dta.V0TERMO_COD_USUR = result[i++].Value?.ToString();
            dta.V0TERMO_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
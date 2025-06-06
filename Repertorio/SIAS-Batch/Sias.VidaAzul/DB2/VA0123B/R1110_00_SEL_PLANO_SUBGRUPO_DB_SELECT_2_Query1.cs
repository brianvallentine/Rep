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
    public class R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1 : QueryBasis<R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_SUBGRUPO
            INTO :SUBGVGAP-COD-SUBGRUPO
            FROM SEGUROS.VG_PLANO_SUBGRUPO
            WHERE COD_EMPRESA_SIVPF = 001
            AND COD_OPCAO_COBER = :PROPOVA-OPCAO-COBERTURA
            AND IND_PERIOD_PGTO = :PRODUVG-PERI-PAGAMENTO
            AND IND_OPCAO_CONJUGE =
            :VG130-IND-OPCAO-CONJUGE
            AND COD_TIPO_ASSISTENCIA =
            :VG130-COD-TIPO-ASSISTENCIA
            AND NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND STA_REGISTRO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_SUBGRUPO
											FROM SEGUROS.VG_PLANO_SUBGRUPO
											WHERE COD_EMPRESA_SIVPF = 001
											AND COD_OPCAO_COBER = '{this.PROPOVA_OPCAO_COBERTURA}'
											AND IND_PERIOD_PGTO = '{this.PRODUVG_PERI_PAGAMENTO}'
											AND IND_OPCAO_CONJUGE =
											'{this.VG130_IND_OPCAO_CONJUGE}'
											AND COD_TIPO_ASSISTENCIA =
											'{this.VG130_COD_TIPO_ASSISTENCIA}'
											AND NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND STA_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string VG130_COD_TIPO_ASSISTENCIA { get; set; }
        public string PROPOVA_OPCAO_COBERTURA { get; set; }
        public string VG130_IND_OPCAO_CONJUGE { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1 Execute(R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1 r1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1)
        {
            var ths = r1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
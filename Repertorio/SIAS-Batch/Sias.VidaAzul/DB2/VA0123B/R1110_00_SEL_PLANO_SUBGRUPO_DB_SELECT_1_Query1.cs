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
    public class R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_OPCAO_CONJUGE ,
            COD_TIPO_ASSISTENCIA ,
            STA_REGISTRO
            INTO :VG130-IND-OPCAO-CONJUGE ,
            :VG130-COD-TIPO-ASSISTENCIA ,
            :VG130-STA-REGISTRO
            FROM SEGUROS.VG_PLANO_SUBGRUPO
            WHERE COD_EMPRESA_SIVPF = 001
            AND COD_OPCAO_COBER = :PROPOVA-OPCAO-COBERTURA
            AND IND_PERIOD_PGTO = :OPCPAGVI-PERI-PAGAMENTO
            AND NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IND_OPCAO_CONJUGE 
							,
											COD_TIPO_ASSISTENCIA 
							,
											STA_REGISTRO
											FROM SEGUROS.VG_PLANO_SUBGRUPO
											WHERE COD_EMPRESA_SIVPF = 001
											AND COD_OPCAO_COBER = '{this.PROPOVA_OPCAO_COBERTURA}'
											AND IND_PERIOD_PGTO = '{this.OPCPAGVI_PERI_PAGAMENTO}'
											AND NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string VG130_IND_OPCAO_CONJUGE { get; set; }
        public string VG130_COD_TIPO_ASSISTENCIA { get; set; }
        public string VG130_STA_REGISTRO { get; set; }
        public string PROPOVA_OPCAO_COBERTURA { get; set; }
        public string OPCPAGVI_PERI_PAGAMENTO { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1 Execute(R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1 r1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = r1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG130_IND_OPCAO_CONJUGE = result[i++].Value?.ToString();
            dta.VG130_COD_TIPO_ASSISTENCIA = result[i++].Value?.ToString();
            dta.VG130_STA_REGISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
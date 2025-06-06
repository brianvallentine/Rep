using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1 : QueryBasis<R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO ,
            COD_PRODUTO
            INTO :VG130-NUM-APOLICE ,
            :VG130-COD-SUBGRUPO ,
            :VG130-COD-PRODUTO
            FROM SEGUROS.VG_PLANO_SUBGRUPO
            WHERE COD_EMPRESA_SIVPF = 001
            AND COD_PRODUTO_SIVPF = :VG130-COD-PRODUTO-SIVPF
            AND COD_OPCAO_COBER = :VG130-COD-OPCAO-COBER
            AND IND_PERIOD_PGTO = :VG130-IND-PERIOD-PGTO
            AND IND_OPCAO_CONJUGE = :VG130-IND-OPCAO-CONJUGE
            AND COD_TIPO_ASSISTENCIA = :VG130-COD-TIPO-ASSISTENCIA
            AND :WHOST-DATA-PROPOSTA BETWEEN DTA_INI_VIGENCIA
            AND DTA_FIM_VIGENCIA
            AND STA_REGISTRO = '0'
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											COD_PRODUTO
											FROM SEGUROS.VG_PLANO_SUBGRUPO
											WHERE COD_EMPRESA_SIVPF = 001
											AND COD_PRODUTO_SIVPF = '{this.VG130_COD_PRODUTO_SIVPF}'
											AND COD_OPCAO_COBER = '{this.VG130_COD_OPCAO_COBER}'
											AND IND_PERIOD_PGTO = '{this.VG130_IND_PERIOD_PGTO}'
											AND IND_OPCAO_CONJUGE = '{this.VG130_IND_OPCAO_CONJUGE}'
											AND COD_TIPO_ASSISTENCIA = '{this.VG130_COD_TIPO_ASSISTENCIA}'
											AND '{this.WHOST_DATA_PROPOSTA}' BETWEEN DTA_INI_VIGENCIA
											AND DTA_FIM_VIGENCIA
											AND STA_REGISTRO = '0'";

            return query;
        }
        public string VG130_NUM_APOLICE { get; set; }
        public string VG130_COD_SUBGRUPO { get; set; }
        public string VG130_COD_PRODUTO { get; set; }
        public string VG130_COD_TIPO_ASSISTENCIA { get; set; }
        public string VG130_COD_PRODUTO_SIVPF { get; set; }
        public string VG130_IND_OPCAO_CONJUGE { get; set; }
        public string VG130_COD_OPCAO_COBER { get; set; }
        public string VG130_IND_PERIOD_PGTO { get; set; }
        public string WHOST_DATA_PROPOSTA { get; set; }

        public static R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1 Execute(R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1 r0352_00_VALIDA_PLANO_DB_SELECT_1_Query1)
        {
            var ths = r0352_00_VALIDA_PLANO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0352_00_VALIDA_PLANO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG130_NUM_APOLICE = result[i++].Value?.ToString();
            dta.VG130_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.VG130_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
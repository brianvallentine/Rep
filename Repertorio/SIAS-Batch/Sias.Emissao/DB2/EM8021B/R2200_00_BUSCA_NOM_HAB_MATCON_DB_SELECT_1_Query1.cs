using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1 : QueryBasis<R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_UNO
            OPERACAO,
            PONTO_VENDA,
            NUM_CONTRATO,
            CGCCPF,
            NOME_SEGURADO,
            DATA_NASC
            INTO :SINIHAB1-COD-UNO
            :SINIHAB1-OPERACAO,
            :SINIHAB1-PONTO-VENDA,
            :SINIHAB1-NUM-CONTRATO,
            :SINIHAB1-CGCCPF,
            :SINIHAB1-NOME-SEGURADO,
            :SINIHAB1-DATA-NASC
            FROM SEGUROS.SINISTRO_HABIT01
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_UNO
											OPERACAO
							,
											PONTO_VENDA
							,
											NUM_CONTRATO
							,
											CGCCPF
							,
											NOME_SEGURADO
							,
											DATA_NASC
											FROM SEGUROS.SINISTRO_HABIT01
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINIHAB1_COD_UNO { get; set; }
        public string SINIHAB1_OPERACAO { get; set; }
        public string SINIHAB1_PONTO_VENDA { get; set; }
        public string SINIHAB1_NUM_CONTRATO { get; set; }
        public string SINIHAB1_CGCCPF { get; set; }
        public string SINIHAB1_NOME_SEGURADO { get; set; }
        public string SINIHAB1_DATA_NASC { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1 Execute(R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1 r2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1)
        {
            var ths = r2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIHAB1_COD_UNO = result[i++].Value?.ToString();
            dta.SINIHAB1_OPERACAO = string.IsNullOrWhiteSpace(dta.SINIHAB1_COD_UNO) ? "-1" : "0";
            dta.SINIHAB1_PONTO_VENDA = result[i++].Value?.ToString();
            dta.SINIHAB1_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.SINIHAB1_CGCCPF = result[i++].Value?.ToString();
            dta.SINIHAB1_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.SINIHAB1_DATA_NASC = result[i++].Value?.ToString();
            return dta;
        }

    }
}
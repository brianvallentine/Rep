using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1 : QueryBasis<M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_COBERTURA
            INTO :SUBGVGAP-OPCAO-COBERTURA
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT OPCAO_COBERTURA
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.VGSOLFAT_COD_SUBGRUPO}'
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_OPCAO_COBERTURA { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1 Execute(M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1 m_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1)
        {
            var ths = m_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_5530_UPDATE_HISTCONTABILVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_OPCAO_COBERTURA = result[i++].Value?.ToString();
            return dta;
        }

    }
}
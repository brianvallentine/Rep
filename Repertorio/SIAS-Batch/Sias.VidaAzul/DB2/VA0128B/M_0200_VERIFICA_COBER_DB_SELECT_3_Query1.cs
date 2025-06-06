using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0200_VERIFICA_COBER_DB_SELECT_3_Query1 : QueryBasis<M_0200_VERIFICA_COBER_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(TAXA_VG),0)
            INTO
            :FAIXASAL-TAXA-VG
            FROM
            SEGUROS.FAIXA_SALARIAL
            WHERE
            NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPVA-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(TAXA_VG)
							,0)
											FROM
											SEGUROS.FAIXA_SALARIAL
											WHERE
											NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPVA_CODSUBES}'";

            return query;
        }
        public string FAIXASAL_TAXA_VG { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }

        public static M_0200_VERIFICA_COBER_DB_SELECT_3_Query1 Execute(M_0200_VERIFICA_COBER_DB_SELECT_3_Query1 m_0200_VERIFICA_COBER_DB_SELECT_3_Query1)
        {
            var ths = m_0200_VERIFICA_COBER_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0200_VERIFICA_COBER_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0200_VERIFICA_COBER_DB_SELECT_3_Query1();
            var i = 0;
            dta.FAIXASAL_TAXA_VG = result[i++].Value?.ToString();
            return dta;
        }

    }
}
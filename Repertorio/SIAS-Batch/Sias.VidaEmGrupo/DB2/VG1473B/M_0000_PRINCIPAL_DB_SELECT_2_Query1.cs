using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1473B
{
    public class M_0000_PRINCIPAL_DB_SELECT_2_Query1 : QueryBasis<M_0000_PRINCIPAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SEQ_GERACAO
            INTO :GEARDETA-SEQ-GERACAO
            FROM SEGUROS.GE_AR_DETALHE
            WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SEQ_GERACAO
											FROM SEGUROS.GE_AR_DETALHE
											WHERE NOM_ARQUIVO = '{this.GEARDETA_NOM_ARQUIVO}'";

            return query;
        }
        public string GEARDETA_SEQ_GERACAO { get; set; }
        public string GEARDETA_NOM_ARQUIVO { get; set; }

        public static M_0000_PRINCIPAL_DB_SELECT_2_Query1 Execute(M_0000_PRINCIPAL_DB_SELECT_2_Query1 m_0000_PRINCIPAL_DB_SELECT_2_Query1)
        {
            var ths = m_0000_PRINCIPAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0000_PRINCIPAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0000_PRINCIPAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.GEARDETA_SEQ_GERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
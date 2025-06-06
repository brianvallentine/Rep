using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1 : QueryBasis<M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :WS-QTD-RISCO-GRAVADO
            FROM SEGUROS.VG_ANDAMENTO_PROP
            WHERE NUM_CERTIFICADO = :VG078-NUM-CERTIFICADO
            AND DES_ANDAMENTO LIKE
            '%PROPOSTA COM CLASSIFICACAO DE RISCO%'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.VG_ANDAMENTO_PROP
											WHERE NUM_CERTIFICADO = '{this.VG078_NUM_CERTIFICADO}'
											AND DES_ANDAMENTO LIKE
											'%PROPOSTA COM CLASSIFICACAO DE RISCO%'
											WITH UR";

            return query;
        }
        public string WS_QTD_RISCO_GRAVADO { get; set; }
        public string VG078_NUM_CERTIFICADO { get; set; }

        public static M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1 Execute(M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1 m_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1)
        {
            var ths = m_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8590_00_GRAVA_ANDAMENTO_PROP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_QTD_RISCO_GRAVADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
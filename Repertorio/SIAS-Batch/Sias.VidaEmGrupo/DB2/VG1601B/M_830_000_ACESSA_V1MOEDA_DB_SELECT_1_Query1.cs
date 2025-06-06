using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1601B
{
    public class M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCRUZAD
            INTO :DVLCRUZAD-IMP
            FROM SEGUROS.V1MOEDA
            WHERE
            CODUNIMO = :ECOD-MOEDA-IMP AND
            DTINIVIG <= :SISTEMAS-DATA-MOV-ABERTO AND
            DTTERVIG >= :SISTEMAS-DATA-MOV-ABERTO AND
            SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE
											CODUNIMO = '{this.ECOD_MOEDA_IMP}' AND
											DTINIVIG <= '{this.SISTEMAS_DATA_MOV_ABERTO}' AND
											DTTERVIG >= '{this.SISTEMAS_DATA_MOV_ABERTO}' AND
											SITUACAO = '0'";

            return query;
        }
        public string DVLCRUZAD_IMP { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string ECOD_MOEDA_IMP { get; set; }

        public static M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1 Execute(M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1 m_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = m_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.DVLCRUZAD_IMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}
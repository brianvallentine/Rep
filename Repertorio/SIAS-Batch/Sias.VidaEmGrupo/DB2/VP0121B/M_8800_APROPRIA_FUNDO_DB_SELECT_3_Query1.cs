using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1 : QueryBasis<M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PCCOMCOR
            INTO :FUNDO-PCCOMSUP
            FROM SEGUROS.V0PARCOMVA
            WHERE CODPRODU = :PROPVA-CODPRODU
            AND PERIPGTO = :OPCAOP-PERIPGTO
            AND DTINIVIG <= :PROPVA-DTQITBCO
            AND DTTERVIG >= :PROPVA-DTQITBCO
            AND TIPCOM = '2'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCCOMCOR
											FROM SEGUROS.V0PARCOMVA
											WHERE CODPRODU = '{this.PROPVA_CODPRODU}'
											AND PERIPGTO = '{this.OPCAOP_PERIPGTO}'
											AND DTINIVIG <= '{this.PROPVA_DTQITBCO}'
											AND DTTERVIG >= '{this.PROPVA_DTQITBCO}'
											AND TIPCOM = '2'
											WITH UR";

            return query;
        }
        public string FUNDO_PCCOMSUP { get; set; }
        public string PROPVA_CODPRODU { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string PROPVA_DTQITBCO { get; set; }

        public static M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1 Execute(M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1 m_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1)
        {
            var ths = m_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1();
            var i = 0;
            dta.FUNDO_PCCOMSUP = result[i++].Value?.ToString();
            return dta;
        }

    }
}
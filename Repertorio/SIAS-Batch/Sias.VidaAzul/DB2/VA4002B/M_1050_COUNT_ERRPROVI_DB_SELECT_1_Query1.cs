using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1 : QueryBasis<M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUBSTR(VALUE(B.DES_ABREV_MSG_CRITICA, ' ' ),1,40)
            INTO :ERROSVID-DESCR-ERRO
            FROM SEGUROS.VG_CRITICA_PROPOSTA A,
            SEGUROS.VG_DM_MSG_CRITICA B
            WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND A.COD_MSG_CRITICA IN (401,402,501,1301,1811,
            1872,1873,1874,1875)
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUBSTR(VALUE(B.DES_ABREV_MSG_CRITICA
							, ' ' )
							,1
							,40)
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
							,
											SEGUROS.VG_DM_MSG_CRITICA B
											WHERE A.NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND A.COD_MSG_CRITICA IN (401
							,402
							,501
							,1301
							,1811
							,
											1872
							,1873
							,1874
							,1875)
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string ERROSVID_DESCR_ERRO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1 Execute(M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1 m_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1)
        {
            var ths = m_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1050_COUNT_ERRPROVI_DB_SELECT_1_Query1();
            var i = 0;
            dta.ERROSVID_DESCR_ERRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R9130_00_SELECT_TITULO_DB_SELECT_1_Query1 : QueryBasis<R9130_00_SELECT_TITULO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_PLANO
            ,A.NUM_SERIE
            ,A.NUM_TITULO
            ,A.IND_DV
            ,A.DTH_INI_VIGENCIA
            ,A.DTH_FIM_VIGENCIA
            ,B.DES_COMBINACAO
            INTO
            :FCTITULO-NUM-PLANO ,
            :FCTITULO-NUM-SERIE ,
            :FCTITULO-NUM-TITULO ,
            :FCTITULO-IND-DV ,
            :FCTITULO-DTH-INI-VIGENCIA ,
            :FCTITULO-DTH-FIM-VIGENCIA ,
            :FCCOMTIT-DES-COMBINACAO
            FROM FDRCAP.FC_TITULO A
            JOIN FDRCAP.FC_COMB_TITULOS B
            ON A.IDE_SERIEPADRAO = B.IDE_SERIEPADRAO
            AND A.NUM_TITULO = B.NUM_TITULO
            WHERE A.NUM_PROPOSTA = :V0BILH-NUMBIL
            AND B.NUM_COMBINACAO = 1
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_PLANO
											,A.NUM_SERIE
											,A.NUM_TITULO
											,A.IND_DV
											,A.DTH_INI_VIGENCIA
											,A.DTH_FIM_VIGENCIA
											,B.DES_COMBINACAO
											FROM FDRCAP.FC_TITULO A
											JOIN FDRCAP.FC_COMB_TITULOS B
											ON A.IDE_SERIEPADRAO = B.IDE_SERIEPADRAO
											AND A.NUM_TITULO = B.NUM_TITULO
											WHERE A.NUM_PROPOSTA = '{this.V0BILH_NUMBIL}'
											AND B.NUM_COMBINACAO = 1
											WITH UR";

            return query;
        }
        public string FCTITULO_NUM_PLANO { get; set; }
        public string FCTITULO_NUM_SERIE { get; set; }
        public string FCTITULO_NUM_TITULO { get; set; }
        public string FCTITULO_IND_DV { get; set; }
        public string FCTITULO_DTH_INI_VIGENCIA { get; set; }
        public string FCTITULO_DTH_FIM_VIGENCIA { get; set; }
        public string FCCOMTIT_DES_COMBINACAO { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R9130_00_SELECT_TITULO_DB_SELECT_1_Query1 Execute(R9130_00_SELECT_TITULO_DB_SELECT_1_Query1 r9130_00_SELECT_TITULO_DB_SELECT_1_Query1)
        {
            var ths = r9130_00_SELECT_TITULO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9130_00_SELECT_TITULO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9130_00_SELECT_TITULO_DB_SELECT_1_Query1();
            var i = 0;
            dta.FCTITULO_NUM_PLANO = result[i++].Value?.ToString();
            dta.FCTITULO_NUM_SERIE = result[i++].Value?.ToString();
            dta.FCTITULO_NUM_TITULO = result[i++].Value?.ToString();
            dta.FCTITULO_IND_DV = result[i++].Value?.ToString();
            dta.FCTITULO_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.FCTITULO_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.FCCOMTIT_DES_COMBINACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1 : QueryBasis<R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.COD_EXT_SEGURADO
            , A.COD_PESSOA_SOCIO
            , A.NUM_PROPOSTA
            , A.COD_FONTE
            INTO :LTMVPROP-COD-EXT-SEGURADO
            ,:LTMVPROP-COD-PESSOA-SOCIO
            ,:LTMVPROP-NUM-PROPOSTA
            ,:LTMVPROP-COD-FONTE
            FROM SEGUROS.LT_MOV_PROPOSTA A
            ,SEGUROS.ENDOSSOS B
            WHERE A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_PROPOSTA = B.NUM_PROPOSTA
            AND A.COD_EXT_SEGURADO = :LTMVPROP-COD-EXT-SEGURADO
            AND B.NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND :SISTEMAS-DATA-MOV-ABERTO BETWEEN
            B.DATA_INIVIGENCIA AND
            B.DATA_TERVIGENCIA
            AND B.NUM_ENDOSSO = 0
            ORDER BY A.DATA_MOVIMENTO DESC
            FETCH FIRST ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.COD_EXT_SEGURADO
											, A.COD_PESSOA_SOCIO
											, A.NUM_PROPOSTA
											, A.COD_FONTE
											FROM SEGUROS.LT_MOV_PROPOSTA A
											,SEGUROS.ENDOSSOS B
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_PROPOSTA = B.NUM_PROPOSTA
											AND A.COD_EXT_SEGURADO = '{this.LTMVPROP_COD_EXT_SEGURADO}'
											AND B.NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND '{this.SISTEMAS_DATA_MOV_ABERTO}' BETWEEN
											B.DATA_INIVIGENCIA AND
											B.DATA_TERVIGENCIA
											AND B.NUM_ENDOSSO = 0
											ORDER BY A.DATA_MOVIMENTO DESC
											FETCH FIRST ROWS ONLY
											WITH UR";

            return query;
        }
        public string LTMVPROP_COD_EXT_SEGURADO { get; set; }
        public string LTMVPROP_COD_PESSOA_SOCIO { get; set; }
        public string LTMVPROP_NUM_PROPOSTA { get; set; }
        public string LTMVPROP_COD_FONTE { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1 Execute(R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1 r7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1)
        {
            var ths = r7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTMVPROP_COD_EXT_SEGURADO = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_PESSOA_SOCIO = result[i++].Value?.ToString();
            dta.LTMVPROP_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}
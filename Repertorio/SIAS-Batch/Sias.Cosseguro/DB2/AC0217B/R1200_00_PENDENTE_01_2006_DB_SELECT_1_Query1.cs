using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0217B
{
    public class R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1 : QueryBasis<R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLR_COSSEGURO
            INTO :GE396-VLR-COSSEGURO
            FROM SEGUROS.GE_SINISTRO_ANALITICO
            WHERE NUM_SINISTRO = :COSHISSI-NUM-SINISTRO
            AND NUM_ANO_REFER = 2006
            AND NUM_MES_REFER = 01
            AND NUM_DIA_REFER = 31
            AND IND_TIPO_MOVTO = :GE396-IND-TIPO-MOVTO
            AND COD_TIPO_OPER = :GE396-COD-TIPO-OPER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLR_COSSEGURO
											FROM SEGUROS.GE_SINISTRO_ANALITICO
											WHERE NUM_SINISTRO = '{this.COSHISSI_NUM_SINISTRO}'
											AND NUM_ANO_REFER = 2006
											AND NUM_MES_REFER = 01
											AND NUM_DIA_REFER = 31
											AND IND_TIPO_MOVTO = '{this.GE396_IND_TIPO_MOVTO}'
											AND COD_TIPO_OPER = '{this.GE396_COD_TIPO_OPER}'";

            return query;
        }
        public string GE396_VLR_COSSEGURO { get; set; }
        public string COSHISSI_NUM_SINISTRO { get; set; }
        public string GE396_IND_TIPO_MOVTO { get; set; }
        public string GE396_COD_TIPO_OPER { get; set; }

        public static R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1 Execute(R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1 r1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE396_VLR_COSSEGURO = result[i++].Value?.ToString();
            return dta;
        }

    }
}
using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1 : QueryBasis<RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NUM_ITEM ,
            ID_MESTRE_EXPURGO,
            RAMO ,
            SITUACAO_APOLICE ,
            DATA_SITUACAO ,
            COD_CLIENTE
            INTO :DCLAPOLICE-EXPURGO.APOLIEXP-NUM-APOLICE ,
            :DCLAPOLICE-EXPURGO.APOLIEXP-NUM-ITEM ,
            :DCLAPOLICE-EXPURGO.APOLIEXP-ID-MESTRE-EXPURGO,
            :DCLAPOLICE-EXPURGO.APOLIEXP-RAMO ,
            :DCLAPOLICE-EXPURGO.APOLIEXP-SITUACAO-APOLICE ,
            :DCLAPOLICE-EXPURGO.APOLIEXP-DATA-SITUACAO ,
            :DCLAPOLICE-EXPURGO.APOLIEXP-COD-CLIENTE
            FROM EXPURGO.APOLICE_EXPURGO
            WHERE NUM_APOLICE = :V0SEG-NUM-APOL
            AND NUM_ITEM = :V0SEG-NUM-ITEM
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NUM_ITEM 
							,
											ID_MESTRE_EXPURGO
							,
											RAMO 
							,
											SITUACAO_APOLICE 
							,
											DATA_SITUACAO 
							,
											COD_CLIENTE
											FROM EXPURGO.APOLICE_EXPURGO
											WHERE NUM_APOLICE = '{this.V0SEG_NUM_APOL}'
											AND NUM_ITEM = '{this.V0SEG_NUM_ITEM}'";

            return query;
        }
        public string APOLIEXP_NUM_APOLICE { get; set; }
        public string APOLIEXP_NUM_ITEM { get; set; }
        public string APOLIEXP_ID_MESTRE_EXPURGO { get; set; }
        public string APOLIEXP_RAMO { get; set; }
        public string APOLIEXP_SITUACAO_APOLICE { get; set; }
        public string APOLIEXP_DATA_SITUACAO { get; set; }
        public string APOLIEXP_COD_CLIENTE { get; set; }
        public string V0SEG_NUM_APOL { get; set; }
        public string V0SEG_NUM_ITEM { get; set; }

        public static RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1 Execute(RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1 rB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1)
        {
            var ths = rB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new RB224_00_LER_APOL_EXPURGO_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLIEXP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLIEXP_NUM_ITEM = result[i++].Value?.ToString();
            dta.APOLIEXP_ID_MESTRE_EXPURGO = result[i++].Value?.ToString();
            dta.APOLIEXP_RAMO = result[i++].Value?.ToString();
            dta.APOLIEXP_SITUACAO_APOLICE = result[i++].Value?.ToString();
            dta.APOLIEXP_DATA_SITUACAO = result[i++].Value?.ToString();
            dta.APOLIEXP_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}
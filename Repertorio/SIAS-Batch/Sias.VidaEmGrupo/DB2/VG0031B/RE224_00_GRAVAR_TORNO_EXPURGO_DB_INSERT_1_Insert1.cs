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
    public class RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1 : QueryBasis<RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO EXPURGO.RETORNO_EXPURGO
            VALUES (:V1SIST-DTMOVABE ,
            :DCLAPOLICE-EXPURGO.APOLIEXP-NUM-APOLICE,
            :DCLAPOLICE-EXPURGO.APOLIEXP-NUM-ITEM ,
            :DCLAPOLICE-EXPURGO.APOLIEXP-ID-MESTRE-EXPURGO ,
            'VG0031B' ,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO EXPURGO.RETORNO_EXPURGO VALUES ({FieldThreatment(this.V1SIST_DTMOVABE)} , {FieldThreatment(this.APOLIEXP_NUM_APOLICE)}, {FieldThreatment(this.APOLIEXP_NUM_ITEM)} , {FieldThreatment(this.APOLIEXP_ID_MESTRE_EXPURGO)} , 'VG0031B' , 0)";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string APOLIEXP_NUM_APOLICE { get; set; }
        public string APOLIEXP_NUM_ITEM { get; set; }
        public string APOLIEXP_ID_MESTRE_EXPURGO { get; set; }

        public static void Execute(RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1 rE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1)
        {
            var ths = rE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}
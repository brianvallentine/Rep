using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R0910_00_INSERT_GE366_DB_INSERT_1_Insert1 : QueryBasis<R0910_00_INSERT_GE366_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_MOVIMENTO
            (NUM_OCORR_MOVTO,
            COD_EVENTO,
            IDE_SISTEMA,
            DTH_MOVIMENTO,
            IND_ESTRUTURA,
            IND_ORIGEM_FUNC,
            DTH_CADASTRAMENTO,
            IND_EVENTO,
            NOM_PROGRAMA,
            COD_USUARIO )
            VALUES
            (:GE366-NUM-OCORR-MOVTO,
            :GE366-COD-EVENTO,
            :GE366-IDE-SISTEMA,
            :GE366-DTH-MOVIMENTO,
            :GE366-IND-ESTRUTURA,
            :GE366-IND-ORIGEM-FUNC,
            CURRENT TIMESTAMP,
            :GE366-IND-EVENTO,
            :GE366-NOM-PROGRAMA,
            :GE366-COD-USUARIO:WIND-COD-USUARIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_MOVIMENTO (NUM_OCORR_MOVTO, COD_EVENTO, IDE_SISTEMA, DTH_MOVIMENTO, IND_ESTRUTURA, IND_ORIGEM_FUNC, DTH_CADASTRAMENTO, IND_EVENTO, NOM_PROGRAMA, COD_USUARIO ) VALUES ({FieldThreatment(this.GE366_NUM_OCORR_MOVTO)}, {FieldThreatment(this.GE366_COD_EVENTO)}, {FieldThreatment(this.GE366_IDE_SISTEMA)}, {FieldThreatment(this.GE366_DTH_MOVIMENTO)}, {FieldThreatment(this.GE366_IND_ESTRUTURA)}, {FieldThreatment(this.GE366_IND_ORIGEM_FUNC)}, CURRENT TIMESTAMP, {FieldThreatment(this.GE366_IND_EVENTO)}, {FieldThreatment(this.GE366_NOM_PROGRAMA)},  {FieldThreatment((this.WIND_COD_USUARIO?.ToInt() == -1 ? null : this.GE366_COD_USUARIO))})";

            return query;
        }
        public string GE366_NUM_OCORR_MOVTO { get; set; }
        public string GE366_COD_EVENTO { get; set; }
        public string GE366_IDE_SISTEMA { get; set; }
        public string GE366_DTH_MOVIMENTO { get; set; }
        public string GE366_IND_ESTRUTURA { get; set; }
        public string GE366_IND_ORIGEM_FUNC { get; set; }
        public string GE366_IND_EVENTO { get; set; }
        public string GE366_NOM_PROGRAMA { get; set; }
        public string GE366_COD_USUARIO { get; set; }
        public string WIND_COD_USUARIO { get; set; }

        public static void Execute(R0910_00_INSERT_GE366_DB_INSERT_1_Insert1 r0910_00_INSERT_GE366_DB_INSERT_1_Insert1)
        {
            var ths = r0910_00_INSERT_GE366_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0910_00_INSERT_GE366_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}
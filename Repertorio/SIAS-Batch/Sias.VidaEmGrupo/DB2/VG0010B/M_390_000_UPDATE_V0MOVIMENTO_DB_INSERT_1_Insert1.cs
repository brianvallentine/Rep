using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1 : QueryBasis<M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VG0010B' ,
            :V1SISTEMA-DTMOVABE,
            'VP' ,
            'VP0198B' ,
            0,
            0,
            CURRENT DATE,
            CURRENT DATE,
            CURRENT DATE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :MNUM-APOLICE,
            0,
            0,
            :V0RELA-NRCERTIF,
            0,
            :MCOD-SUBGRUPO,
            :MCOD-OPERACAO,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            ' ' ,
            ' ' ,
            ' ' ,
            NULL,
            0,
            NULL,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VG0010B' , {FieldThreatment(this.V1SISTEMA_DTMOVABE)}, 'VP' , 'VP0198B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.MNUM_APOLICE)}, 0, 0, {FieldThreatment(this.V0RELA_NRCERTIF)}, 0, {FieldThreatment(this.MCOD_SUBGRUPO)}, {FieldThreatment(this.MCOD_OPERACAO)}, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , ' ' , ' ' , ' ' , NULL, 0, NULL, CURRENT TIMESTAMP)";

            return query;
        }
        public string V1SISTEMA_DTMOVABE { get; set; }
        public string MNUM_APOLICE { get; set; }
        public string V0RELA_NRCERTIF { get; set; }
        public string MCOD_SUBGRUPO { get; set; }
        public string MCOD_OPERACAO { get; set; }

        public static void Execute(M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1 m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1)
        {
            var ths = m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}